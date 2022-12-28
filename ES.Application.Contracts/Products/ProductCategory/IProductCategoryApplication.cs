using ES.Application.Contracts.Products.ProductCategory.DTOs;
using ES.Application.Contracts.Products.ProductCategory.ViewModels;

namespace ES.Application.Contracts.Products.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Add(CreateProductCategoryCommand command);
        List<ProductCategoryViewModel> GetAll();
        bool IsValid(long id);
        ProductCategoryViewModel GetBy(long id);
        void Edit(EditProductCategoryCommand command);
        void Remove(long id);
        void Activate(long id);
    }
}
