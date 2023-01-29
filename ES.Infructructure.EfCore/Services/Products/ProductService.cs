using ES.Domain.Entities.Products.Product;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductService : Repository<long, Product>, IProductService
    {
        private readonly EcommerceContext context;
        public ProductService(EcommerceContext context) : base(context)
        {
            this.context = context;
            products = new List<Product>();
        }

        public async Task<double> GetMinimumPrice(long id)
        {
            var product = await GetBy(id);
            var item = product.ProductItems.MinBy(x => x.Price);
            if(item != null) { return item.Price; }
            return 0;
        }

        public async Task<int> GetTotalQuantity(long id)
        {
            var product = await GetBy(id);
            int sum = 0;
            product.ProductItems.ForEach(x => sum += x.Quantity);
            return sum;
        }
        private List<Product> products;
        public async Task<List<Product>> GetByCategory(long categoryId)
        {
            var category = await context.productCategories.FindAsync(categoryId);
            products.AddRange(category.Products);
            foreach (var item in category.ChildeCategories)
            {
                await GetByCategory(item.Id);
            }
            return products;
        }
    }
}   