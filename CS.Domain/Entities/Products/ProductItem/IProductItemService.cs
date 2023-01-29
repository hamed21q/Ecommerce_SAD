using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.ProductItem
{
    public interface IProductItemService : IRepository<long, ProductItem>
    {
        Task<List<ProductItem>> GetAllSibllings(long productId);
        Task<List<ProductConfiguration.ProductConfiguration>> GetConfiguration(long id);
    }
}
