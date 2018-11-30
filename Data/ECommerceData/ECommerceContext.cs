using ECommerceData.Cart;
using ECommerceData.Customer;
using ECommerceData.InventoryManagement.Inventory;
using ECommerceData.InventoryManagement.Product;
using ECommerceData.Order;
using ECommerceData.User;
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

        internal DbSet<CustomerDTO> Customers { get; set; }

        internal DbSet<CartDTO> Cart { get; set; }

        internal DbSet<Product.ProductDTO> Products { get; set; }

        internal DbSet<OrderDTO> Orders { get; set; }

        internal DbSet<InventoryDTO> Inventory { get; set; }

        internal DbSet<ProductDTO> InventoryProducts { get; set; }
    }
}
