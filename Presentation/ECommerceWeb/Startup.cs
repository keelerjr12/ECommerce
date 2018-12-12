using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerceApplication.Inventory;
using ECommerceApplication.Ordering.Customer.Queries;
using ECommerceData;
using ECommerceData.Cart;
using ECommerceData.Identity.User;
using ECommerceData.Inventory.Inventory;
using ECommerceData.Product;
using ECommerceData.Sales.Customer;
using ECommerceData.Sales.Order;
using ECommerceDomain.InventoryManagement.Inventory;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ECommerceDomain.Ordering.Customer;
using ECommerceDomain.Ordering.Order;
using ECommerceDomain.Shopping.Cart;
using ECommerceDomain.Shopping.Product;
using ECommerceWeb.Areas.Products.Models;

namespace ECommerceWeb
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
            services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                }).AddCookie(options => { options.LoginPath = "/Authentication/Login"; });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductViewModel>();
                cfg.CreateMap<CustomerQuery.Result, Customer>();
            });

            services.AddDbContext<ECommerceContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ECommerceContext")));

            services.AddScoped<ECommerceContext>();
            services.AddScoped<UnitOfWork>();

            services.AddMediatR();

            services.AddScoped<UserRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<InventoryService>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ECommerceDomain.InventoryManagement.Product.IProductRepository,
                ECommerceData.Inventory.Product.ProductRepository > ();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.AllowAreas = true;
                options.Conventions.AuthorizeAreaFolder("Admin", "/");
            });
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
