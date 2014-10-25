using System.Diagnostics;

namespace WebShop.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public int Count { get; set; }

        public float TotalPrice
        {
            [DebuggerStepThrough]
            get { return Count * Price; }
        }
    }
}