using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.Products.ProductVariation;
using ES.Domain.Entities.Products.ProductVariationOption;
using ES.Domain.Entities.Users.Country;
using ES.Domain.Entities.Users.Role;
using ES.Infructructure.EfCore.Mappings.Products;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore
{
    public class EcommerceContext : DbContext
    {
        //products
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<ProductVariationOption> productVariationOptions { get; set; }
        public DbSet<ProductItem> productItems { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public EcommerceContext(DbContextOptions<EcommerceContext> context) : base(context) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
