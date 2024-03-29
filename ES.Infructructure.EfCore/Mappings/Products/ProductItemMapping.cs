﻿using ES.Domain.Entities.Products.ProductItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Mappings.Products
{
    public class ProductItemMapping : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price);
            builder.Property(x => x.Quantity);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductItems)
                .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.Configurations)
                .WithOne(x => x.ProductItem)
                .HasForeignKey(x => x.ProductItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ProductImages)
                .WithOne(x => x.ProductItem)
                .HasForeignKey(x => x.ProductItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}