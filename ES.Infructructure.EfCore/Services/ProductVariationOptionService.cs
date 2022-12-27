using ES.Domain.Entities.Products.ProductVariationOption;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services
{
    public class ProductVariationOptionService : Repository<long, ProductVariationOption>, IProductVariationOptionService
    {
        public ProductVariationOptionService(EcommerceContext context) : base(context)
        {
        }

        public List<ProductVariationOption> GetbyVariation(long variationId)
        {
            return _context.Set<ProductVariationOption>().Where(pvo => pvo.VariationId == variationId).ToList();
        }
    }
}
