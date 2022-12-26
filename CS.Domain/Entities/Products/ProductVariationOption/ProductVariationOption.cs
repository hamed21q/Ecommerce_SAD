using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Domain.Entities.Products.ProductConfiguration;

namespace ES.Domain.Entities.Products.ProductVariationOption
{
    public class ProductVariationOption : BaseDomain
    {
        public long VariationId { get; private set; }
        public string Value { get; set; }

        //navigation
        public virtual ProductVariation.ProductVariation Variation { get; set; }
        public virtual List<ProductConfiguration.ProductConfiguration> Configurations { get; set; }
        public ProductVariationOption(long variationId, string value) : base()
        {
            Configurations = new List<ProductConfiguration.ProductConfiguration>();
            VariationId = variationId;
            Value = value;
        }
        public void Edit(long variationId, string value)
        {
            Value = value;
            VariationId = variationId;
        }
    }
}
