using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariationOption.DTOs
{
    public class EditProductVariationOptionCommand : CreateProductVariationOptionCommand
    {
        public long Id { get; set; }
    }
}
