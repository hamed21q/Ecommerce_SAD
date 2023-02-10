using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.ShoppingCart.ShoppingCart;

namespace ES.Domain.Entities.ShoppingCart.ShppingCartItem
{
    public class ShoppingCartItem : BaseDomain
    {
        public long CartId { get; set; }
        public long ProductItemId { get; set; }
        public int Qty { get; set; }

        public virtual ShoppingCart.ShoppingCart Cart { get; set; }
        public virtual ProductItem ProductItem { get; set; }
        public ShoppingCartItem(long cartId, long productItemId, int qty)
        {
            CartId = cartId;
            ProductItemId = productItemId;
            Qty = qty;
        }
    }
}
