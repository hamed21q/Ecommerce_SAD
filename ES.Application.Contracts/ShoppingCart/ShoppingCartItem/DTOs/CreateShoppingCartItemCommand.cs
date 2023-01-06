using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ShoppingCart.ShoppingCartItem.DTOs
{
    public class CreateShoppingCartItemCommand
    {
        public long CartId { get; set; }
        public long ProductItemId { get; set; }
        public string Qty { get; set; }
    }
}
