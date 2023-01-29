using ES.Domain.Entities.Products.ProductVariationOption;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductVariationOptionService : Repository<long, ProductVariationOption>, IProductVariationOptionService
    {
        public ProductVariationOptionService(EcommerceContext context) : base(context)
        {
        }

        public async Task<List<ProductVariationOption>> GetbyVariation(long variationId)
        {
            return await _context.Set<ProductVariationOption>().Where(pvo => pvo.VariationId == variationId).ToListAsync();
        }
    }
}
