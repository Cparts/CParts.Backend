using System;
using System.Text;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Core.Model.Internal;
using CParts.Framework.Options;
using CParts.Infrastructure.Business;
using CParts.Infrastructure.Data.Contexts;
using CParts.Infrastructure.Data.Repositories.Parts;
using CParts.Business.Abstractions;
using CParts.Domain.Abstractions.Repositories.Internal;
using CParts.Infrastructure.Data.Repositories.Internal;
using CParts.Infrastructure.Services;
using CParts.Infrastructure.Services.Internal;
using CParts.Infrastructure.Services.Parts;
using CParts.Services.Abstractions;
using CParts.Services.Abstractions.Internal;
using CParts.Services.Abstractions.Parts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace CParts.BootStrapper
{
    public static class Bootstrapper
    {
        public static IServiceCollection BootstrapDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();

            var connectionSettingsSection = configuration.GetSection(nameof(ConnectionSettings));
            var jwtSettingsSection = configuration.GetSection(nameof(JwtSettings));
            var corsSettingsSection = configuration.GetSection(nameof(CorsSettings));

            services.Configure<ConnectionSettings>(x => connectionSettingsSection.Bind(x));
            services.Configure<CorsSettings>(x => corsSettingsSection.Bind(x));
            services.Configure<JwtSettings>(x => jwtSettingsSection.Bind(x));
            
            //Identity and entity framework setup
            services.AddEntityFrameworkMySQL()
                .AddDbContext<PartsDataDbContext>(options =>
                    options.UseMySQL(
                        connectionSettingsSection.GetSection(nameof(ConnectionStrings))["PartsData:Test"]))
                .AddDbContext<InternalDataDbContext>(options =>
                    options.UseMySQL(
                        connectionSettingsSection.GetSection(nameof(ConnectionStrings))["InternalData:Test"]))
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<InternalDataDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = jwtSettingsSection["Audience"],
                        ValidateAudience = true,
                        ValidIssuer = jwtSettingsSection["Issuer"],
                        ValidateIssuer = true,

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5),

                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingsSection["SecurityKeyValue"])),
                        ValidateIssuerSigningKey = true,
                    };
                });


            services.AddScoped<IPartsDataDbContext>(provider =>
                provider.GetRequiredService<PartsDataDbContext>());
            services.AddScoped<IInternalDataDbContext>(provider =>
                provider.GetRequiredService<InternalDataDbContext>());

            services.RegisterServices();

            return services;
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Designations repositories
            services.AddTransient<ICountryDesignationsRepository, CountryDesignationsRepository>();
            services.AddTransient<IGeneralDesignationsRepository, GeneralDesignationsRepository>();

            //Separate entities repositories
            services.AddTransient<IArticlesRepository, ArticlesRepository>();
            services.AddTransient<IManufacturersRepository, ManufacturersRepository>();
            services.AddTransient<IModelsRepository, ModelsRepository>();
            services.AddTransient<ISearchTreeRepository, SearchTreeRepository>();
            services.AddTransient<ITypesRepository, TypesRepository>();
            services.AddTransient<IApplicationUsersRepository, ApplicationUsersRepository>();

            //Links repositories
            services.AddTransient<IArticleLinkToTypeLinkRepository, ArticleLinkToTypeLinkRepository>();
            services.AddTransient<IGroupToArticleLinkRepository, GroupToArticleLinkRepository>();
            services.AddTransient<IGroupToTreeLinkRepository, GroupToTreeLinkRepository>();
            services.AddTransient<IArticleLookupRepository, ArticleLookupRepository>();
            services.AddTransient<IArticleCriteriasRepository, ArticleCriteriasRepository>();

            //
            services.AddTransient<IArticlesService, ArticlesService>();
            services.AddTransient<ISearchTreeService, SearchTreeService>();
            services.AddTransient<IPartApplicabilityService, PartApplicabilityService>();
            services.AddTransient<ICarSelectionService, CarSelectionService>();
            services.AddTransient<IArticleAnaloguesService, ArticleAnaloguesService>();
            services.AddTransient<IAuthorizationService, AuthroizationService>();

            services.AddTransient<IArticlesServiceMapper, ArticlesServiceMapper>();
            services.AddTransient<IApplicabilityServiceMapper, ApplicabilityServiceMapper>();
            services.AddTransient<ICarSelectionServiceMapper, CarSelectionServiceMapper>();
            services.AddTransient<IAnaloguesServiceMapper, AnaloguesServiceMapper>();
            services.AddTransient<IAuthorizationServiceMapper, AuthorizationServiceMapper>();

            return services;
        }

        public static IApplicationBuilder BootstrapMiddleware(this IApplicationBuilder app,
            IConfiguration configuration)
        {
//            app.UseAuthentication();
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