using ES.Domain.DomainService;

namespace ES.Domain.Entities.Product
{
    public interface IProductService : IRepository<long, Product>
    {
        List<Product> GetProductsBy(long categoryId);
    }
}
