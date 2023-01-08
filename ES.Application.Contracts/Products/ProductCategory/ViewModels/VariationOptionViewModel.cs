using ES.Application.Contracts.Products.ProductVariationOption.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductCategory.ViewModels
{
    public class VariationOptionViewModel
    {
        public string Name { get; set; }
        public List<ProductVariationOptionViewModel> options { get; set; }
    }
}
