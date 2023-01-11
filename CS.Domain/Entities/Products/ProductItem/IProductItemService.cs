using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.ProductItem
{
    public interface IProductItemService : IRepository<long, ProductItem>
    {
        List<ProductItem> GetAllSibllings(long productId);
        List<ProductConfiguration.ProductConfiguration> GetConfiguration(long id);
    }
}
