﻿using ES.Domain.Entities.ShoppingCart.ShoppingCart;
using ES.Domain.Entities.Users.Country;
using ES.Infructructure.EfCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.ShoppingCart
{
    public class ShoppingCartService : Repository<long, Domain.Entities.ShoppingCart.ShoppingCart.ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(EcommerceContext context) : base(context)
        {

        }
    }
}
