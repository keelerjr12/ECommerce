using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerceApplication.CartService;
using ECommerceApplication.Identity;
using ECommerceApplication.Inventory;
using ECommerceApplication.Ordering.Customer;
using ECommerceApplication.Ordering.Order;
using ECommerceData;
using ECommerceData.Cart;
using ECommerceData.Identity.User;
using ECommerceData.InventoryManagement.Inventory;
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
                }).AddCookie(options => { options.LoginPath = "/Login"; });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                //options.Conventions.AuthorizeFolder("/");
                options.Conventions.AuthorizePage("/Account");
                options.Conventions.AuthorizePage("/Register");
                options.Conventions.AuthorizePage("/Cart");
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductViewModel>();
                cfg.CreateMap<CustomerQueryResult, Customer>();
            });

            services.AddDbContext<ECommerceContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ECommerceContext")));

            services.AddScoped<ECommerceContext>();
            services.AddScoped<UnitOfWork>();

            services.AddMediatR();

            services.AddScoped<IdentityService>();
            services.AddScoped<UserRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<CartService>();
            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<InventoryService>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ECommerceDomain.InventoryManagement.Product.IProductRepository,
                ECommerceData.InventoryManagement.Product.ProductRepository > ();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.AllowAreas = true;
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
