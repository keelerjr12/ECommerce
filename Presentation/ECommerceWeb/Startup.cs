using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerceApplication.Ordering.Customer.Queries;
using ECommerceData;
using ECommerceData.Identity.User;
using ECommerceData.Inventory.Inventory;
using ECommerceData.Ordering.Customer;
using ECommerceData.Ordering.Order;
using ECommerceData.Shopping.Cart;
using ECommerceData.Shopping.Product;
using ECommerceData.Shopping.ProductCategory;
using ECommerceDomain.Inventory.Inventory;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ECommerceDomain.Ordering.Customer;
using ECommerceDomain.Ordering.Order;
using ECommerceDomain.Shopping.Cart;
using ECommerceDomain.Shopping.Product;
using ECommerceDomain.Shopping.ProductCategory;
using ECommerceWeb.Areas.Account.Models.Inventory;
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
                }).AddCookie(options =>
                {
                    options.LoginPath = "/Authentication/Login";
                    options.AccessDeniedPath = "/Index";
                });

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
                cfg.CreateMap<ECommerceApplication.Inventory.InventoryItemDTO, InventoryItemViewModel>();
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
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IInventoryRepository, InventoryRepository>();

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("RequireSeller", builder =>
                {
                    builder.RequireRole("Seller");
                });

                cfg.AddPolicy("RequireCustomer", builder =>
                {
                    builder.RequireRole("Customer");
                });
            });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.AllowAreas = true;
                options.Conventions.AuthorizeAreaFolder("Account", "/Seller", "RequireSeller");
                options.Conventions.AuthorizeAreaFolder("Account", "/Customer", "RequireCustomer");
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
