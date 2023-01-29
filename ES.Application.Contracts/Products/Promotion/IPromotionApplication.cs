using ES.Application.Contracts.Products.Promotion.DTOs;
using ES.Application.Contracts.Products.Promotion.ViewModels;

namespace ES.Application.Contracts.Products.Promotion
{
    public interface IPromotionApplication
    {
        Task Add(CreateShoppingCartCommand command);
        Task Edit(EditShoppingCartCommand command);
        Task<ShoppingCartViewmodels> GetdBy(long id);
        Task<List<ShoppingCartViewmodels>> GetAll();
        Task Delete(long id);
    }
}
