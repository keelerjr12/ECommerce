using ECommerceData.Cart;
using ECommerceData.Inventory;
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
            modelBuilder.Entity<InventoryItemDTO>().HasKey(i => new {i.InventoryId, i.ProductSKU});
        }

        internal DbSet<CartDTO> Cart { get; set; }
        internal DbSet<Product.ProductDTO> Products { get; set; }

        internal DbSet<InventoryDTO> Inventory { get; set; }
    }
}
