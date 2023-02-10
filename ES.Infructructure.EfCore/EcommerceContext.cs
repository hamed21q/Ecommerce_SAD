using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Domain.Entities.Products.ProductConfiguration;
using ES.Domain.Entities.Products.ProductItem;
using ES.Domain.Entities.Products.ProductItemImage;
using ES.Domain.Entities.Products.ProductVariation;
using ES.Domain.Entities.Products.ProductVariationOption;
using ES.Domain.Entities.Users.Country;
using ES.Domain.Entities.Users.Role;
using ES.Domain.Entities.Users.User;
using ES.Domain.Entities.Users.UserAddress;
using ES.Infructructure.EfCore.Mappings.Products;
using ES.Infructructure.EfCore.Mappings.ShoppingCart;
using ES.Infructructure.EfCore.Mappings.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
        public DbSet<User> users { get; set; }
        public DbSet<UserAddress> userAddresses { get; set; }
        public DbSet<ProductConfiguration> productConfigurations { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public EcommerceContext(DbContextOptions<EcommerceContext> context) : base(context) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CountryMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserAddressMapping());
            modelBuilder.ApplyConfiguration(new UserRoleMapping());
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductConfigurationMapping());
            modelBuilder.ApplyConfiguration(new ProductVariationMapping());
            modelBuilder.ApplyConfiguration(new ProductVariationOptionMapping());
            modelBuilder.ApplyConfiguration(new ProductItemMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ShoppingCartItemMapping());
            modelBuilder.ApplyConfiguration(new ShoppingCartMapping());


            base.OnModelCreating(modelBuilder);
        }
    }
}
