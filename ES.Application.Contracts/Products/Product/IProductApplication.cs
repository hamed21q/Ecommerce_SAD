using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.Product.ViewModels;
using ES.Application.Contracts.Products.ProductItem.ViewModels;

namespace ES.Application.Contracts.Products.Product
{
    public interface IProductApplication
    {
        void Add(CreateProductCommand command);
        bool IsValid(long id);
        void Edit(EditProductCommand command);
        ProductViewModel GetBy(long id);
        List<ProductViewModel> GetByCategory(long id);
        void Delete(long id);
    }
}
