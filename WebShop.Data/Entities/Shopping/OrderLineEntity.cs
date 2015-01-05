using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Data.Entities.Shopping
{
    [Table("OrderLines")]
    public class OrderLineEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ArticleId { get; set; }

        public float Price { get; set; }

        public int Count { get; set; }
    }
}