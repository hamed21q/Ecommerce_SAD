using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductItemImage;

namespace ES.Domain.Entities.Products.ProductItem
{
    public interface IProductItemService : IRepository<long, ProductItem>
    {
        Task AddImage(long itemid, ProductImage images);
        Task<List<ProductItem>> GetAllSibllings(long productId);
        Task<List<ProductConfiguration.ProductConfiguration>> GetConfiguration(long id);
        void RemoveImage(ProductImage image);
    }
}
