using ES.Application.Contracts.Products.ProductItem.DTOs;
using ES.Application.Contracts.Products.ProductItem.ViewModels;

namespace ES.Application.Contracts.Products.ProductItem
{
    public interface IProductItemApplication
    {
        void Add(CreateProductItemCommand command);
        void Edit(EditProductItemCommand command);
        void Delete(long id);
        ProductItemViewModel GetBy(long id);
        List<ProductItemViewModel> GetAllSibllings(long productId);

    }
}
