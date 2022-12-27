using ES.Application.Contracts.Products.ProductCategory;
using ES.Application.Products;
using ES.Domain.DomainService;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Infructructure.EfCore;
using ES.Infructructure.EfCore.Base;
using ES.Infructructure.EfCore.Services.Products;
using ES.Infructructure.EfCore.Services.Products.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ES.Infrustructure.Core
{
    public class Bootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<EcommerceContext>(option => option.UseSqlServer(connectionString));
        }
    }
}