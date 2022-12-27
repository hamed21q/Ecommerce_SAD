using ES.Domain.DomainService;

namespace ES.Domain.Entities.ProductCategory
{
    public interface IProductCategoryService : IRepository<long, ProductCategory>
    {
    }
}
