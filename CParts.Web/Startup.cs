using System;
using System.IO;
using CParts.BootStrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace CParts.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.BootstrapDI(Configuration);
            services.Configure<MvcJsonOptions>(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info {Title = "CParts backend", Version = "v0.1a"});
                //TODO: Make this work in a smarter way
                var dir = new DirectoryInfo(AppContext.BaseDirectory);
                options.IncludeXmlComments($"{dir.Parent.Parent.Parent.FullName}/TodoApi.xml");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CParts backend API v0.1a");
            });
            
            app.UseAuthentication();

            app.BootstrapMiddleware(Configuration);
            
            app.UseMvc();
        }
    }
}