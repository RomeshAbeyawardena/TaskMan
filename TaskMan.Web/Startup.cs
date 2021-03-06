using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using DNI.Shared.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskMan.Broker;
using FluentValidation.AspNetCore;

namespace TaskMan.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews();

            services
                .AddDistributedMemoryCache()
                .RegisterServiceBroker<ServiceBroker>(options => { 
                options.RegisterAutoMappingProviders = true;
                options.RegisterCacheProviders = true;
                options.RegisterExceptionHandlers = true;
                options.RegisterMediatorServices = true;
                options.RegisterMessagePackSerialisers = true;
            }, out var serviceBrokerInstance);

            services.AddAutoMapper(Assembly.GetAssembly(typeof(Domains.DomainProfile)));

            services
                .AddMvc()
                .AddFluentValidation(configuration => configuration
                .RegisterValidatorsFromAssemblies(serviceBrokerInstance.Assemblies));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
