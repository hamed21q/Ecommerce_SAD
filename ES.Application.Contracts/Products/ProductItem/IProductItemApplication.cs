using ES.Application.Contracts.Products.ProductItem.DTOs;
using ES.Application.Contracts.Products.ProductItem.ViewModels;

namespace ES.Application.Contracts.Products.ProductItem
{
    public interface IProductItemApplication
    {
        Task Add(CreateProductItemCommand command);
        Task Edit(EditProductItemCommand command);
        Task Delete(long id);
        Task<ProductItemViewModel> GetBy(long id);
        Task<List<ProductItemViewModel>> GetAllSibllings(long productId);

    }
}
