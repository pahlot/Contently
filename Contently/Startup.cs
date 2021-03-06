﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Contently.Core.Domain;
using Contently.Core.Data.Interfaces;
using Contently.Data.Dapper;
using Contently.Core.Web.Routing;
using Contently.Core.DiscoveryServices;
using Contently.Core.RouteStores;

namespace Contently
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.ConfigureRouting(setupAction =>
            //{
            //    setupAction.LowercaseUrls = true;
            //});

            // Add framework services.
            services.AddMvc();

            // add data services
            services.AddScoped<IContentDataService<RoutablePage>, MockPageRepository>();
            services.AddSingleton<IContentTypeDiscoveryService, ContentTypeDiscoveryService>();
            services.AddSingleton<IRouteStore, InMemoryRouteStore>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

           
            app.UseStaticFiles();
           // app.UseIdentity();

            app.UseMvc(routes =>
            {
                // Put all routes first so they get handled first. The Contently UrlSLug handler should only try last. It'll also handle 404 errors
                //routes.MapRoute(
                //      name: "AreaRoutes",
                //      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                // TODO: add all this into a registration extension so we're not duplicating code
                routes.Routes.Add(new UrlSlugRouter(routes.DefaultHandler, 
                    dataService: routes.ServiceProvider.GetRequiredService<IContentDataService<RoutablePage>>(), 
                    routeStore: routes.ServiceProvider.GetRequiredService<IRouteStore>()));

            });
        }
    }
}
