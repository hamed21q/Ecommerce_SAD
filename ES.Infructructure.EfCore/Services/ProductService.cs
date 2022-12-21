using ES.Domain.Entities.Product;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services
{
    public class ProductService : Repository<long, Product>, IProductService
    {
        public ProductService(EcommerceContext context) : base(context)
        {

        }

        public List<Product> GetProductsBy(long categoryId)
        {
            return _context.Set<Product>().Where(product => product.CategoryId == categoryId).ToList();
        }
    }
}
