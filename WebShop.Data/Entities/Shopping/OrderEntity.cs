using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Data.Entities.Shopping
{
    [Table( "Orders" )]
    public class OrderEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int CustomerId { get; set; }

        public float SubTotal { get; set; }

        public float Vat { get; set; }

        public float Total { get; set; }

        public DateTime Created { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Closed { get; set; }
    }
}