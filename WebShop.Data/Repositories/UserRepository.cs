using System.Linq;
using WebShop.Data.Entities.Profile;

namespace WebShop.Data.Repositories
{
    public interface IUserRepository
    {
        bool AddIfNotExists(string userName);
    }

    public class UserRepository : IUserRepository
    {
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