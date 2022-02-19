using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.mocks;
using TestAspNet3.data.Repository;
using TestAspNet3.Views.models;

namespace TestAspNet3
{
    public class Startup
    {
        private IConfigurationRoot configurationDb;
        
        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            configurationDb = new ConfigurationBuilder()
                .SetBasePath(webHostEnvironment.ContentRootPath)
                .AddJsonFile("dbSettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DB>(options => options.UseSqlServer(configurationDb.GetConnectionString("DefaultConnection")));

            services.AddTransient<IProducts, ProductRepository>();
            services.AddTransient<ICategories, CategoryRepository>();
            services.AddTransient<IOrders, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(sp => Cart.GetCart(sp));

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=index}/{id?}");
                routes.MapRoute(name: "category", 
                    template: "{controller=Products}/{action}/{category?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                DB db = scope.ServiceProvider.GetRequiredService<DB>();
                DbObjects.Initial(db);
            }
        }
    }
}
