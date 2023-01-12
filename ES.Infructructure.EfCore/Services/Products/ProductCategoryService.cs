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

        public List<Product> GetAllProductsBy(long categoryId)
        {
            var category = GetBy(categoryId);
            return category.Products;
        }
        private List<ProductCategory> categories;
        public List<ProductCategory> GetSubCategories(long id)
        {
            var category = GetBy(id);
            categories.AddRange(category.ChildeCategories);
            foreach (var item in category.ChildeCategories)
            {
                GetSubCategories(item.Id);
            }
            return categories;
        }
    }
}
