using ES.Application;
using ES.Application.Contracts.ProductCategory;
using ES.Domain;
using ES.Domain.Entities.ProductCategory;
using ES.Infructructure.EfCore;
using ES.Infructructure.EfCore.Services;
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