using ES.Domain.Entities.ShoppingCart.ShppingCartItem;
using ES.Domain.Entities.Users.Country;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.ShoppingCart
{
    public class ShoppingCartItemService : Repository<long, ShoppingCartItem>, IShoppingCartItemService
    {
        public ShoppingCartItemService(DbContext context) : base(context)
        {
        }
    }
}
