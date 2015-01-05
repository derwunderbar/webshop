using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Data.Entities.Profile;

namespace WebShop.Data.Entities.Shopping
{
    [Table("Customers")]
    public class CustomerEntity
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual UserProfileEntity User { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string HouseNumber { get; set; }

        public string ZipCode { get; set; }
    }
}