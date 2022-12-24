using ES.Application.Contracts.Product.DTOs;
using ES.Application.Contracts.Product.ViewModels;
namespace ES.Application.Contracts.Product
{
    public interface IProductApplication
    {
        void Add(CreateProductCommand command);
        bool IsValid(long id);
        void Edit(EditProductCommand command);
        ProductViewModel GetBy(long id);
        List<ProductViewModel> GetByCategory(long id);
        void Delete(long id);
        ProductViewModel Convert(Domain.Entities.Product.Product product);
    }
}
