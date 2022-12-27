using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.ProductCategory
{
    public interface IProductCategoryService : IRepository<long, ProductCategory>
    {
    }
}
