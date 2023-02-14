using ES.Domain.Entities.ShoppingCart.ShppingCartItem;
using ES.Domain.Entities.Users.User;

namespace ES.Domain.Entities.ShoppingCart.ShoppingCart
{
    public class ShoppingCart
    {
        public long UserId { get; set; }
        public List<ShoppingCartItem> shopingCartItems { get; set; }
        public ShoppingCart()
        {

        }
        public ShoppingCart(string username)
        {
            Username = username;
        }
        public Decimal TotalPrice
        {
            get
            {
                decimal price = 0;
                foreach (var item in shopingCartItems)
                {
                    price += item.Price;
                }
                return price;
            }
        }
    }
}
