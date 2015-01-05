using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace WebShop.ViewModels
{
    [Serializable]
    [Bind(Exclude = "TotalPrice")]
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