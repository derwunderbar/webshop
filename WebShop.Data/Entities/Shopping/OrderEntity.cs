using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Data.Entities.Profile;

namespace WebShop.Data.Entities.Shopping
{
    [Table( "Orders" )]
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual UserProfileEntity User { get; set; }

        public int CustomerId { get; set; }

        public virtual CustomerEntity Customer { get; set; }

        public float SubTotal { get; set; }

        public float Vat { get; set; }

        public float Total { get; set; }

        public DateTime Created { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Closed { get; set; }
    }
}