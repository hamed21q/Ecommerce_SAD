using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Domain.Entities.Products.ProductItem;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductCategoryService : Repository<long, ProductCategory>, IProductCategoryService
    {
        private readonly EcommerceContext context;
        public ProductCategoryService(EcommerceContext context) : base(context)
        {
            categories = new List<ProductCategory>();
            this.context = context;
        }

        public async Task<List<Product>> GetAllProductsBy(long categoryId)
        {
            var category = await GetBy(categoryId);
            return category.Products;
        }
        private List<ProductCategory> categories;
        public async Task<List<ProductCategory>> GetSubCategories(long id)
        {
            var category = await GetBy(id);
            categories.AddRange(category.ChildeCategories);
            foreach (var item in category.ChildeCategories)
            {
                await GetSubCategories(item.Id);
            }
            return categories;
        }
    }
}