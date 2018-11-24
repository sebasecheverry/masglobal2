using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Employees
{
    public class Startup
    {        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            

            ApplicationSettings.ApiEndPointUrl = configuration.GetSection("CustomProjectSettings").GetSection("WebApiBaseUrl").Value;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });

                options.AddPolicy("CorsAllowSpecific",
                    p => p.WithHeaders("Content-Type", "Accept", "Auth-Token")
                        .WithMethods("POST", "PUT", "DELETE")
                        .SetPreflightMaxAge(new TimeSpan(1728000))
                        .AllowAnyOrigin()
                        .AllowCredentials()
                    );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }            
            app.UseHttpsRedirection();
            var corsAllowAll = Configuration["CustomProjectSettings:CorsAllowAll"] ?? "false";
            app.UseCors(corsAllowAll == "true" ? "CorsAllowAll" : "CorsAllowSpecific");
            app.UseMvc();            
        }
    }
}
