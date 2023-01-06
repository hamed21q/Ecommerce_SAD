using ES.Domain.Entities.Products.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.ShoppingCart.ShppingCartItem
{
    public class ShoppingCartItem : BaseDomain
    {
        public long CartId { get; set; }
        public long ProductItemId { get; set; }
        public string Qty { get; set;  }
    }

    public ShoppingCartItem(long cartId, long productItemId, string qty)
    {
        CartId = cartId;
        ProductItemId = productItemId;
        Qty = qty;
    }
}
