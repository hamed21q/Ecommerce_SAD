using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductImage
{
    public class CreateProduceImageCommand
    {
        public long productItemId { get; set; }
        public byte[] Image { get; set; }
    }
}
