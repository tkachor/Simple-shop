using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simple_Shop.Data;
using Simple_Shop.Data.Interfaces;
using Simple_Shop.Data.mocks;
using Simple_Shop.Data.Models;
using Simple_Shop.Data.Repository;

namespace Simple_Shop
{
    public class Startup
    {
        private IConfigurationRoot _confString;
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbSettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProduct, ProductReposirory>();
            services.AddTransient<IProductCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository > ();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(option => option.EnableEndpointRouting = false);   
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDBContent>();
                context.Database.EnsureCreated();
            }
            app.UseDeveloperExceptionPage();  
            app.UseStatusCodePages();
            app.UseStaticFiles(); 
            app.UseSession();
            app.UseMvcWithDefaultRoute(); 
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller-Home}/{action-Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Product/{action}/{category?}", defaults: new { Controller = "Product", action = "List" });
                });

            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
           
        }
    }
}
