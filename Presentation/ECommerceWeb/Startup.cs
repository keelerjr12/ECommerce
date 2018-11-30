using ECommerceApplication;
using ECommerceApplication.AuthService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerceApplication.CartService;
using ECommerceApplication.InventoryService;
using ECommerceApplication.Reporting;
using ECommerceData;
using ECommerceData.Cart;
using ECommerceData.Customer;
using ECommerceData.InventoryManagement.Inventory;
using ECommerceData.Product;
using ECommerceData.User;
using ECommerceDomain.InventoryManagement.Inventory;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Customer;
using ECommerceDomain.Sales.Order;
using ECommerceDomain.Sales.Product;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

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
                options.Conventions.AuthorizePage("/Cart");
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ECommerceContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ECommerceContext")));

            services.AddScoped<ECommerceContext>();
            services.AddScoped<UnitOfWork>();

            services.AddScoped<AuthService>();
            services.AddScoped<UserRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<CartService>();
            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<InventoryService>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ECommerceDomain.InventoryManagement.Product.IProductRepository,
                ECommerceData.InventoryManagement.Product.ProductRepository > ();
            services.AddScoped<InventoryLevelReport>();

            services.AddScoped<CustomerService>();

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
