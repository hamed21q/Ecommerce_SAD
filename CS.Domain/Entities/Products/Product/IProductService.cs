using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.Product
{
    public interface IProductService : IRepository<long, Product>
    {
        Task<double> GetMinimumPrice(long id);
        Task<List<Product>> GetByCategory(long categoryId);
        Task<int> GetTotalQuantity(long id);
    }
}
