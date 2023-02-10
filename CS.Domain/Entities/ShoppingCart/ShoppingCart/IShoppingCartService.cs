using ES.Domain.DomainService;

namespace ES.Domain.Entities.ShoppingCart.ShoppingCart
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetBasket(string username);
        Task DeleteBaske(string username);
        Task<ShoppingCart> UpdateBasket(ShoppingCart shopingCart);
    }
}
