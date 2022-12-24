﻿using ES.Domain.Entities.Product;
using ES.Domain.Entities.ProductCategory;
using ES.Domain.Entities.ProductItem;
using ES.Domain.Entities.ProductVariation;
using ES.Domain.Entities.ProductVariationOption;
using ES.Infructructure.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore
{
    public class EcommerceContext : DbContext
    {
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<ProductVariationOption> productVariationOptions { get; set; }
        public DbSet<ProductItem> productItems { get; set; }
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
