using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.ProductVariation
{
    public interface IProductVariationService : IRepository<long, ProductVariation>
    {
        Task<List<ProductVariation>> GetByCategory(long categoryId);
    }
}
