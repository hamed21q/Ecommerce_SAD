using ES.Domain.Entities.Products.ProductVariation;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductVariationService : Repository<long, ProductVariation>, IProductVariationService
    {
        public ProductVariationService(EcommerceContext context) : base(context)
        {
        }

        public List<ProductVariation> GetByCategory(long categoryId)
        {
            return _context.Set<ProductVariation>().Where(v => v.CategoryId == categoryId).ToList();
        }
    }
}
