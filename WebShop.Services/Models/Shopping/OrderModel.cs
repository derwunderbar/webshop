using System;

namespace WebShop.Services.Models.Shopping
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public OrderLineModel[] Lines { get; set; }

        public float SubTotal { get; set; }

        public float Vat { get; set; }

        public float Total { get; set; }

        public DateTime Created { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Closed { get; set; }


        public OrderModel()
        {
            Created = DateTime.UtcNow;
            IsActive = false;
            Closed = null;
        }
    }
}