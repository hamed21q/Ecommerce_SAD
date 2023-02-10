using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductConfiguration;
using ES.Domain.Entities.Products.ProductItemImage;

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
        public virtual List<ProductImage> ProductImages { get; set; }

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
