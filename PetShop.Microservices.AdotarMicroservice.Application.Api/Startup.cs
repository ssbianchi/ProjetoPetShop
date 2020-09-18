using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PetShop.Common.Application.Interfaces.CQRS.Messaging;
using PetShop.Common.Domain.Services;
using PetShop.Common.Infra.Helper.Serializers;
using PetShop.Common.Infra.Messaging.Services;
using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using PetShop.Microservices.AdotarMicroservice.Infra.DataAccess.Contexts;
using PetShop.Microservices.AdotarMicroservice.Infra.DataAccess.Repositories;

namespace PetShop.Microservices.AdotarMicroservice.Application.Api
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
            //Injeção de dependencia. Pensar: Sempre que me pedirem uma interface, eu entrego a classe.
            services.AddControllers();
            services.AddDbContext<AdotarContext>();
            services.AddScoped<DbContext, AdotarContext>();
            services.AddScoped<IAdotarRepository, AdotarRepository>();
            services.AddScoped<IAdotarService, AdotarService>();
            services.AddScoped<ISerializerService, SerializerService>();
            services.AddScoped<IApiApplicationService, ApiApplicationService>();
            services.AddScoped<IMediatorHandler, AzureServiceBusQueue>();


            services.AddAuthorization();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://petshop-sergio-iammicroservice-identity.azurewebsites.net";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "AdotarMicroservice_ApiResource";
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Adotar Microservice API",
                    Description = "Current api for PetShop created by Sergio Bianchi",
                    Contact = new OpenApiContact
                    {
                        Name = "Sergio Bianchi",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/ssbianchi"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Adotar Microservice API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
