﻿using ES.Application.Contracts.Products.ProductItem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ShoppingCart.ShoppingCartItem.ViewModels
{
    public class ShoppingCartItemViewModels
    {
        public long Id { get; set; }
        public ProductItemViewModel ProductItem { get; set; }
        public string Qty { get; set; }
    }
}
