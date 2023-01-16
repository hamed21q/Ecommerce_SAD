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

        public double GetMinimumPrice(long id)
        {
            var product = GetBy(id);
            var item = product.ProductItems.MinBy(x => x.Price);
            if(item != null) { return item.Price; }
            return 0;
        }

        public int GetTotalQuantity(long id)
        {
            var product = GetBy(id);
            int sum = 0;
            product.ProductItems.ForEach(x => sum += x.Quantity);
            return sum;
        }
        private List<Product> products;
        public List<Product> GetByCategory(long categoryId)
        {
            var category = context.productCategories.Find(categoryId);
            products.AddRange(category.Products);
            foreach (var item in category.ChildeCategories)
            {
                GetByCategory(item.Id);
            }
            return products;
        }
    }
}   