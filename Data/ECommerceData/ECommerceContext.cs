using ECommerceData.Cart;
using ECommerceData.Identity.User;
using ECommerceData.InventoryManagement.Inventory;
using ECommerceData.InventoryManagement.Product;
using ECommerceData.Sales.Customer;
using ECommerceData.Sales.Order;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartDTO>().HasMany(c => c.CartItems).WithOne(c => c.Cart).HasForeignKey(c => c.CartId);
            modelBuilder.Entity<CartItemDTO>().HasKey(c => new {c.CartId, c.ProductId});
            
            modelBuilder.Entity<InventoryDTO>().HasMany(i => i.InventoryItems).WithOne(i => i.Inventory).HasForeignKey(i => i.InventoryId);
        }

        internal DbSet<UserDTO> Users { get; set; }

        public DbSet<CustomerDTO> Customers { get; set; }

        internal DbSet<CartDTO> Cart { get; set; }

        public DbSet<Product.ProductDTO> Products { get; set; }

        public DbSet<OrderDTO> Orders { get; set; }

        public DbSet<InventoryDTO> Inventory { get; set; }

        public DbSet<ProductDTO> InventoryProducts { get; set; }
    }
}
