using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Data.Entities.Profile
{
    [Table( "UserProfile" )]
    public class UserProfileEntity
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}