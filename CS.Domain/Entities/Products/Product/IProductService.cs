using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.Product
{
    public interface IProductService : IRepository<long, Product>
    {
        double GetMinimumPrice(long id);
        List<Product> GetByCategory(long categoryId);
        int GetTotalQuantity(long id);
    }
}
