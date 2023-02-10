using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Domain.Entities.Products.ProductConfiguration;
using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.Products.ProductItemImage;
using ES.Domain.Entities.Products.ProductVariation;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductItemService : Repository<long, ProductItem>, IProductItemService
    {
        private readonly EcommerceContext context;
        public ProductItemService(EcommerceContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddImage(long itemid, ProductImage image)
        {
            image.ProductItemId = itemid;
            await context.productImages.AddAsync(image);
            context.SaveChanges();
        }

        public async Task<List<ProductItem>> GetAllSibllings(long productId)
        {
            var product = await context.products.FindAsync(productId);
            if(product == null) { throw new ArgumentException(); }
            return product.ProductItems;
        }

        public async Task<List<ProductConfiguration>> GetConfiguration(long id)
        {
            var item = await GetBy(id);
            return item.Configurations;
        }

        public void RemoveImage(ProductImage image)
        {
            context.productImages.Remove(image);
        }
    }
}
