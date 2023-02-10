using ES.Domain.Entities.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.ShoppingCart.ShoppingCart
{
    public class ShoppingCart : BaseDomain
    {
        public long UserId { get; set; }

        public virtual User User { get; set; }

        public ShoppingCart(long userId)
        { 
            UserId = userId;
        }
    }
}
