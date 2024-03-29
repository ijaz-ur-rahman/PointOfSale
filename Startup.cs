using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PointOfSale.DatabaseService.DBContext;
using PointOfSale.DataService.Helpers;
using PointOfSale.DataService.IServices;
using PointOfSale.DataService.Services;

namespace PointOfSale
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddDbContext<POS_DBContext>(options => options.UseSqlServer(Configuration.GetSection("ConnectionString:DBConnection").Value));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //User
            services.AddScoped<IUserService, UserService>();
            //Category
            services.AddScoped<ICategoryService, CategoryService>();
            //Items
            services.AddScoped<IItemService, ItemService>();
            //Customer
            services.AddScoped<ICustomerService, CustomerService>();
            //Supplier
            services.AddScoped<ISupplierService, SupplierService>();
            //UOM
            services.AddScoped<IUOMService, UOMService>();
            //Payable
            services.AddScoped<IPayableService, PayableService>();
            //Receivable
            services.AddScoped<IReceivableService, ReceivableService>();
            //PurchaseOder
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            //sale order
            services.AddScoped<ISaleOrderService, SaleOrderService>();


            //lookup
            services.AddScoped<ILookupService, LookupService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Auto Mapper Configurations
            services.AddAutoMapper(c => c.AddProfile<AutoMapperProfiles>(), typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseMiddleware(typeof(ExceptionMiddleware));
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.Strict
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
