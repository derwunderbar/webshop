using System.Data.Entity;
using WebShop.Data.Entities.Shopping;

namespace WebShop.Data
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext()
            : base( "DefaultConnection" )
        {}

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderLineEntity> OrderLines { get; set; }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}