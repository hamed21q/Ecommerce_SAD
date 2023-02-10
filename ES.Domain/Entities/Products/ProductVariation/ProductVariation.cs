using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Domain.Entities.Products.ProductVariationOption;

namespace ES.Domain.Entities.Products.ProductVariation
{
    public class ProductVariation : BaseDomain
    {
        public long CategoryId { get; private set; }
        public string Name { get; private set; }

        //navigation
        public virtual ProductCategory.ProductCategory Category { get; set; }
        public virtual List<ProductVariationOption.ProductVariationOption> ProductVariationOptions { get; set; }
        public ProductVariation(long categoryId, string name) : base()
        {
            ProductVariationOptions = new List<ProductVariationOption.ProductVariationOption>();
            CategoryId = categoryId;
            Name = name;
        }
        public void Edit(long categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
