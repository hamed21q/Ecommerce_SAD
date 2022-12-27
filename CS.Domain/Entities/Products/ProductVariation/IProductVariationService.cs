using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.ProductVariation
{
    public interface IProductVariationService : IRepository<long, ProductVariation>
    {
        List<ProductVariation> GetByCategory(long categoryId);
    }
}
