using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductConfiguration.DTOs
{
    public class EditProductConfigurationCommand : CreateProductConfigurationCommand
    {
        public long Id { get; set; }
    }
}
