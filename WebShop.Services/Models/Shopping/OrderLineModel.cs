namespace WebShop.Services.Models.Shopping
{
    public class OrderLineModel
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public float Price { get; set; }

        public int Count { get; set; }
    }
}