using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductVariationOption.DTOs
{
    public class CreateProductVariationOptionCommand
    {
        public long VariationId { get; set; }
        public string Value { get; set; }
    }
}
