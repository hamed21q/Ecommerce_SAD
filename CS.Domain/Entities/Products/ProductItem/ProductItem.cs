using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductConfiguration;

namespace ES.Domain.Entities.Products.ProductItem
{
    public class ProductItem : BaseDomain
    {
        public long ProductId { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        //navigation
        public virtual Product.Product Product { get; set; }
        public virtual List<ProductConfiguration.ProductConfiguration> Configurations { get; set; }

        public ProductItem(long productId, int quantity, double price)
        {
            Configurations = new List<ProductConfiguration.ProductConfiguration>();
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
