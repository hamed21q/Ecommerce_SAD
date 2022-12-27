using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariation.DTOs
{
    public class EditProductVariationCommand : CreateProductVariationCommand
    {
        public long Id { get; set; }
    }
}
