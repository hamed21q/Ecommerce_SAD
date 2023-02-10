using ES.Domain.Entities.Products.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Products.ProductItemImage
{
    public class ProductImage : BaseDomain
    {
        public long ProductItemId { get; set; }
        public byte[] Image { get; private set; }

        public virtual ProductItem.ProductItem ProductItem { get; set; }

        public ProductImage(long productItemId, byte[] image)
        {
            ProductItemId = productItemId;
            Image = image;
        }
    }
}
