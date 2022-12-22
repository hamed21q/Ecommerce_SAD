using ES.Domain.Entities.ProductVariationOption;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
