using ES.Domain.DomainService;
namespace ES.Domain.Entities.Products.ProductCategory
{
    public interface IProductCategoryService : IRepository<long, ProductCategory>
    {
        Task<List<Product.Product>> GetAllProductsBy(long categoryId);
        Task<List<ProductCategory>> GetSubCategories(long id);

    }
}
