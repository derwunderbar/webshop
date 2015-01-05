using System.Data.Entity;
using WebShop.Data.Entities.Profile;

namespace WebShop.Data
{
    // todo: don't expose outside, it should be internal
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
    }
}