using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariation.DTOs
{
    public class CreateProductVariationCommand
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
    }
}
