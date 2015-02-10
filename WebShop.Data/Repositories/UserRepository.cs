using System.Linq;
using WebShop.Data.Contexts;
using WebShop.Data.Entities.Profile;

namespace WebShop.Data.Repositories
{
    public interface IUserRepository
    {
        UserProfileEntity Get( string userName );

        bool AddIfNotExists(string userName);
    }

    public class UserRepository : IUserRepository
    {
        public UserProfileEntity Get(string userName)
        {
            using( var context = new UsersContext() )
            {
                return context.UserProfiles.SingleOrDefault(a => a.UserName.ToLower() == userName.ToLower());
            }
        }

        public bool AddIfNotExists(string userName)
        {
            using( var context = new UsersContext() )
            {
                var user = context.UserProfiles.FirstOrDefault( a => a.UserName.ToLower() == userName.ToLower() );
                if( user == null )
                {
                    // Insert name into the profile table
                    context.UserProfiles.Add(new UserProfileEntity() { UserName = userName });
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}