using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariation.ViewModels
{
    public class DetailedProductVariationViewModel : ProductVariationViewModel
    {
        public List<string> values { get; set; }
    }
}
