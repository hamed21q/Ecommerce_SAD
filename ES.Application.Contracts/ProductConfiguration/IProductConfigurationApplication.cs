using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductConfiguration
{
    public interface IProductConfigurationApplication
    {
        void Add(long productItemId, long variationOptionId);
        void Add(List<long> variations, long itemId);
    }
}
