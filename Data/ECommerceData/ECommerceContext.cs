using ECommerceData.Cart;
using ECommerceData.Product;
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
        }

        internal DbSet<CartDTO> Cart { get; set; }
        internal DbSet<ProductDTO> Products { get; set; }
    }
}
