using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.ProductVariation
{
    public class ProductVariation : BaseDomain
    {
        public long CategoryId { get; private set; }
        public string Name { get; private set; }

        //navigation
        public virtual ProductCategory.ProductCategory Category { get; private set; }
    }
}
