using System.Data.Entity;
using WebShop.Data.Entities.Shopping;

namespace WebShop.Data
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>().HasMany(e => e.OrderLines);
            modelBuilder.Entity<OrderLineEntity>().HasRequired(e => e.Order).WithMany(e => e.OrderLines);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderLineEntity> OrderLines { get; set; }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}