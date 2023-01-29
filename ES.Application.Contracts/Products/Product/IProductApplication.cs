using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.Product.ViewModels;
using ES.Application.Contracts.Products.ProductItem.ViewModels;

namespace ES.Application.Contracts.Products.Product
{
    public interface IProductApplication
    {
        Task Add(CreateProductCommand command);
        Task<bool> IsValid(long id);
        Task Edit(EditProductCommand command);
        Task<DetailedProductViewModel> GetBy(long id);
        Task<List<ProductViewModel>> GetByCategory(long id);
        Task Delete(long id);
        Task<List<ProductItemViewModel>> GetProductItems(long id);
    }
}
