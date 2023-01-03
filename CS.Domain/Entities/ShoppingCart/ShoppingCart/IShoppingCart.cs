using ES.Domain.DomainService;
using ES.Domain.Entities.Users.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.ShoppingCart.ShoppingCart
{
    public interface IShoppingCart : IRepository<long, ShoppingCart>
    {
    }
}
