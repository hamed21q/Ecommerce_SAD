using ES.Domain.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Products.ProductConfiguration
{
    public interface IProductConfigurationService : IRepository<long, ProductConfiguration>
    {
        List<ProductConfiguration> GetConfigsByProductItem(long productItemId);
    }
}
