using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.ProductItem
{
    public class ProductItem : BaseDomain
    {
        public long ProductId { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        //navigation
        public virtual Product.Product Product { get; set; }

        public ProductItem(long productId, int quantity, double price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
        public void Edit(long productId, int quantity, double price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}
