using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace WebShop.ViewModels.Shopping
{
    [Serializable]
    [Bind( Exclude = "SubTotal, Vat, Total")]
    public class CheckoutViewModel
    {
        public CheckoutViewModel()
            : this(0.0f)
        {}

        public CheckoutViewModel(float vatPercents)
        {
            VatPercents = vatPercents;
            Items = new List<ShoppingCartItemViewModel>();
        }

        public float VatPercents { get; set; }

        public List<ShoppingCartItemViewModel> Items { get; set; }

        public float SubTotal
        {
            [DebuggerStepThrough]
            get { return Items != null ? Items.Sum( a => a.TotalPrice ) : 0; }
        }

        public float Vat
        {
            [DebuggerStepThrough]
            get
            {
                return SubTotal * VatPercents / 100;
            }
        }

        public float Total
        {
            [DebuggerStepThrough]
            get { return SubTotal + Vat; }
        }
    }
}