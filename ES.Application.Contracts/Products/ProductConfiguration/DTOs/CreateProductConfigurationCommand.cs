using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductConfiguration.DTOs
{
    public class CreateProductConfigurationCommand
    {
        public long ProductItemId { get; set; }
        public long VariationOptionId { get; set; }
    }
}