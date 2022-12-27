using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.Product
{
    public interface IProductService : IRepository<long, Product>
    {
        List<Product> GetProductsBy(long categoryId);
        ProductCategory.ProductCategory GetProductsCategory(long categoryId);
    }
}
