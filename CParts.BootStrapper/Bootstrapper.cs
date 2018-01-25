using System;
using System.Security.Cryptography.X509Certificates;
using CParts.Domain.Abstractions;
using CParts.Domain.Core;
using CParts.Infrastructure.Data;
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
            services.AddCors();
            
            //Identity and entity framework setup
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<CPartsContext>(options => options.UseSqlServer(configuration["Connection:ConnectionStrings:Test"]))
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CPartsContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<ICPartsContext>(provider => provider.GetRequiredService<CPartsContext>());

            return services;
        }

        public static IApplicationBuilder BootstrapMiddleware(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseAuthentication();
            app.UseCors(builder =>
            {
                IConfigurationSection corsSettingsSection = configuration.GetSection("CorsSettings");
                
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