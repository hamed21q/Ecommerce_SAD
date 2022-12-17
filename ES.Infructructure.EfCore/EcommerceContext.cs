﻿using ES.Domain.ProductCategory;
using ES.Infructructure.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore
{
    public class EcommerceContext : DbContext
    {
        public DbSet<ProductCategory> productCategories { get; set; }
        public EcommerceContext(DbContextOptions<EcommerceContext> context) : base(context) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}