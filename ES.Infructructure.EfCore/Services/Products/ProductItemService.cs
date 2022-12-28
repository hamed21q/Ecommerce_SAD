using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.Products.ProductVariation;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductItemService : Repository<long, ProductItem>, IProductItemService
    {
        private readonly IProductService productService;
        private readonly IProductVariationService productVariationService;
        public ProductItemService(
            EcommerceContext context,
            IProductService productService,
            IProductVariationService productVariationService
        ) : base(context)
        {
            this.productService = productService;
            this.productVariationService = productVariationService;
        }

        public ProductCategory GetCategory(long productId)
        {
            return productService.GetProductsCategory(productId);
        }

        public Product GetProduct(long productId)
        {
            return productService.GetBy(productId);
        }

        List<long> IProductItemService.GetProductVariations(long productItemId)
        {
            var category = GetCategory(productItemId);
            var variations = productVariationService.GetByCategory(category.Id);
            var ids = new List<long>();
            variations.ForEach(v => ids.Add(v.Id));
            return ids;
        }
    }
}
