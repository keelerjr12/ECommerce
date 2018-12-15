using System.Collections.Generic;
using System.Linq;
using ECommerceData.Identity.User;
using ECommerceData.Inventory.Inventory;
using ECommerceData.Inventory.Product;
using ECommerceData.Ordering.Customer;
using ECommerceData.Ordering.Order;
using ECommerceData.Shopping.Cart;
using ECommerceData.Shopping.ProductCategory;
using ECommerceDomain.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData
{
    public class ECommerceContext : DbContext
    {
        public IReadOnlyList<IDomainEvent> DomainEvents => _events.ToList();

        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CartDTO>().HasMany(c => c.CartItems).WithOne(c => c.Cart).HasForeignKey(c => c.CartId);
            modelBuilder.Entity<CartItemDTO>().HasKey(c => new {c.CustomerId, c.ProductId});
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public void RemoveEvent(IDomainEvent domainEvent)
        {
            _events.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _events.Clear();
        }

        public DbSet<UserDTO> Users { get; set; }

        public DbSet<CustomerDTO> Customers { get; set; }

        public DbSet<CartItemDTO> CartItems { get; set; }

        public DbSet<Shopping.Product.ProductDTO> Products { get; set; }

        public DbSet<ProductCategoryDTO> ProductCategories { get; set; }

        public DbSet<OrderDTO> Orders { get; set; }

        public DbSet<InventoryItemDTO> InventoryItems { get; set; }

        public DbSet<ProductDTO> InventoryProducts { get; set; }

        private List<IDomainEvent> _events = new List<IDomainEvent>();
    }
}
