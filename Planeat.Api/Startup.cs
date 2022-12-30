using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Planeat.Core.Repositories;
using Planeat.Infrastructure.Common;
using Planeat.Infrastructure.IcC;
using Planeat.Infrastructure.IcC.Modules;
using Planeat.Infrastructure.Mappers;
using Planeat.Infrastructure.Repositories;
using Planeat.Infrastructure.Services;
using Planeat.Infrastructure.Settings;

namespace Planeat.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var authenticationSettings = new AuthenticationSettings();

            //Configuration.GetSection("Authentication").Bind(authenticationSettings);

            //services.AddAuthentication(option =>
            //{

            //});

            
            //services.AddAuthentication(option =>
            //{
            //    option.DefaultAuthenticateScheme = "Bearer";
            //    option.DefaultScheme = "Bearer";
            //    option.DefaultChallengeScheme = "Bearer";
            //});
            //services.Configure<AuthenticationSettings>(Configuration.GetSection(AuthenticationSettings.SectionName));

            var authenticationSettings = new AuthenticationSettings();
            Configuration.Bind(AuthenticationSettings.SectionName, authenticationSettings);

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
                });

            services.AddMemoryCache();
            services.AddControllers();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planeat.Api", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.

            builder.RegisterModule(new ContainerModule(Configuration));
            //builder.RegisterType<JwtTokenGenerator>().As<IJwtTokenGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planeat.Api v1"));
            }

            ValidatorOptions.Global.LanguageManager.Enabled = false;

            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if (generalSettings.SeedData)
            {
                var datainitializer = app.ApplicationServices.GetService<IDataInitializer>();
                datainitializer.SeedAsync();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
