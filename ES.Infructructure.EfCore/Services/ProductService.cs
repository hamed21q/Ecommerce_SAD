using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services
{
    public class ProductService : Repository<long, Product>, IProductService
    {
        private readonly IProductCategoryService productCategoryService;
        public ProductService(EcommerceContext context, IProductCategoryService productCategoryService) : base(context)
        {
            this.productCategoryService = productCategoryService;   
        }

        public ProductCategory GetProductsCategory(long productId)
        {
            var categoryId = GetBy(productId).CategoryId;
            return productCategoryService.GetBy(categoryId);
        }

        public List<Product> GetProductsBy(long categoryId)
        {
            return _context.Set<Product>().Where(product => product.CategoryId == categoryId).ToList();
        }
    }
}
