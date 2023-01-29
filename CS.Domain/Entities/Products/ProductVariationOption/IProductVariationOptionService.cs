using ES.Domain.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Products.ProductVariationOption
{
    public interface IProductVariationOptionService : IRepository<long, ProductVariationOption>
    {
        Task<List<ProductVariationOption>> GetbyVariation(long variationId);
    }
}
