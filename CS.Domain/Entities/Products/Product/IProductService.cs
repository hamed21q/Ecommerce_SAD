using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductItem;

namespace ES.Domain.Entities.Products.Product
{
    public interface IProductService : IRepository<long, Product>
    {
        double GetMinimumPrice(long id);
        List<Product> GetProductsByCategory(long categoryId);
        int GetTotalQuantity(long id);
    }
}
