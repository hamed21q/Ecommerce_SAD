using ES.Application.Contracts.Products.ProductCategory.DTOs;
using ES.Application.Contracts.Products.ProductCategory.ViewModels;

namespace ES.Application.Contracts.Products.ProductCategory
{
    public interface IProductCategoryApplication
    {
        Task Add(CreateProductCategoryCommand command);
        Task<List<ProductCategoryViewModel>> GetAll();
        Task<bool> IsValid(long id);
        Task<DetailedProductCategoryViewModel> GetBy(long id);
        Task Edit(EditProductCategoryCommand command);
        Task Remove(long id);
        Task Activate(long id);
    }
}
