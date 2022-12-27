using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductItem.DTOs
{
    public class EditProductItemCommand : CreateProductItemCommand
    {
        public long Id { get; set; }
    }
}
