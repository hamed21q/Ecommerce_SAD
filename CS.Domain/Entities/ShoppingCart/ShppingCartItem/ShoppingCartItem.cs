using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.ShoppingCart.ShoppingCart;

namespace ES.Domain.Entities.ShoppingCart.ShppingCartItem
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
