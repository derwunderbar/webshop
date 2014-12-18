namespace WebShop.ViewModels
{
    public class ShoppingCartUpdateViewModel
    {
        public ShoppingCartItemViewModel UpdatedItem { get; set; }

        public int TotalItems { get; set; }

        public float TotalPrice { get; set; }
    }
}