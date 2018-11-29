using ECommerceData.Cart;
using ECommerceData.Customer;
using ECommerceData.InventoryManagement.Inventory;
using ECommerceData.InventoryManagement.Product;
using ECommerceData.Order;
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
            modelBuilder.Entity<CartItemDTO>().HasKey(c => new {c.CartId, c.ProductSKU});

            modelBuilder.Entity<InventoryDTO>().HasMany(i => i.InventoryItems).WithOne(i => i.Inventory)
                .HasForeignKey(i => i.InventoryId);
            modelBuilder.Entity<InventoryItemDTO>().HasKey(i => new {i.InventoryId, i.SKU});

            modelBuilder.Entity<ProductDTO>().HasKey(i => new { i.InventoryId, i.SKU });
        }

        internal DbSet<CustomerDTO> Customers { get; set; }

        internal DbSet<CartDTO> Cart { get; set; }

        internal DbSet<Product.ProductDTO> Products { get; set; }

        internal DbSet<OrderDTO> Orders { get; set; }

        internal DbSet<InventoryDTO> Inventory { get; set; }

        internal DbSet<InventoryManagement.Product.ProductDTO> InventoryProducts { get; set; }
    }
}
