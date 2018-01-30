using CParts.Domain.Abstractions;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Core;
using CParts.Framework.Options;
using CParts.Infrastructure.Data;
using CParts.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CParts.Bootstrapper
{
    public static class Bootstrapper
    {
        public static IServiceCollection BootstrapDI(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionSettingsSection = configuration.GetSection(nameof(ConnectionSettings));
            var jwtSettingsSection = configuration.GetSection(nameof(JwtSettings));
            var corsSettingsSection = configuration.GetSection(nameof(CorsSettings));

            services.Configure<ConnectionSettings>(x => connectionSettingsSection.Bind(x));
            services.Configure<CorsSettings>(x => corsSettingsSection.Bind(x));
            services.Configure<JwtSettings>(x => jwtSettingsSection.Bind(x));

            services.AddCors();

            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Audience = jwtSettingsSection["Audience"];
                    options.Authority = jwtSettingsSection["Authority"];
                    options.ClaimsIssuer = jwtSettingsSection["Issuer"];
                    options.SaveToken = true;
                });

            //Identity and entity framework setup
            services.AddEntityFrameworkMySql()
                .AddDbContext<PartsDataDbContext>(options =>
                    options.UseMySql(
                        connectionSettingsSection.GetSection(nameof(ConnectionStrings))["PartsData:Test"]))
                .AddDbContext<InternalDataDbContext>(options =>
                    options.UseMySql(
                        connectionSettingsSection.GetSection(nameof(ConnectionStrings))["InternalData:Test"]))
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<InternalDataDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IPartsDataDbContext>(provider =>
                provider.GetRequiredService<PartsDataDbContext>());
            services.AddScoped<IInternalDataDbContext>(provider =>
                provider.GetRequiredService<InternalDataDbContext>());

            return services;
        }

        public static IApplicationBuilder BootstrapMiddleware(this IApplicationBuilder app,
            IConfiguration configuration)
        {
            app.UseAuthentication();
            app.UseCors(builder =>
            {
                var corsSettingsSection = configuration.GetSection("CorsSettings");

                if (corsSettingsSection.GetSection("Enabled").Get<bool>())
                {
                    builder.WithHeaders(corsSettingsSection.GetSection("Headers").Get<string[]>());
                    builder.WithOrigins(corsSettingsSection.GetSection("Origins").Get<string[]>());
                    builder.WithMethods(corsSettingsSection.GetSection("Methods").Get<string[]>());
                }
                else
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                }
            });
            return app;
        }
    }
}