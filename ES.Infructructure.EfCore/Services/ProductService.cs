using ES.Domain.Entities.Product;

namespace ES.Infructructure.EfCore.Services
{
    internal class ProductService : Repository<long, Product>, IProductService
    {
        public ProductService(EcommerceContext context) : base(context)
        {

        }
    }
}
