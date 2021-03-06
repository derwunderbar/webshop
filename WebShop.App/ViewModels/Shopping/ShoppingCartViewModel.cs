﻿using System.Diagnostics;
using System.Linq;

namespace WebShop.ViewModels.Shopping
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            Items = new ShoppingCartItemViewModel[0];
        }

        public ShoppingCartItemViewModel[] Items { get; set; }

        public int TotalItems
        {
            [DebuggerStepThrough]
            get { return Items != null ? Items.Sum( a => a.Count ) : 0; }
        }

        public float TotalPrice
        {
            [DebuggerStepThrough]
            get { return Items != null ? Items.Sum( a => a.TotalPrice ) : 0; }
        }
    }
}