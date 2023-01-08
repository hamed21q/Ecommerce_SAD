namespace ES.Domain.Entities.ShoppingCart.ShppingCartItem
{
    public class ShoppingCartItem : BaseDomain
    {
        public long CartId { get; set; }
        public long ProductItemId { get; set; }
        public string Qty { get; set;  }
        public ShoppingCartItem(long cartId, long productItemId, string qty)
        {
            CartId = cartId;
            ProductItemId = productItemId;
            Qty = qty;
        }
    }
}
