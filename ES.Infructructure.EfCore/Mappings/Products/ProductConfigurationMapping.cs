using ES.Domain.Entities.Products.ProductConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Mappings.Products
{
    public class ProductConfigurationMapping : IEntityTypeConfiguration<ProductConfiguration>
    {
        public void Configure(EntityTypeBuilder<ProductConfiguration> builder)
        {
            builder.ToTable("ProductConfigurations");
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.ProductItem)
                .WithMany(x => x.Configurations)
                .HasForeignKey(x => x.ProductItemId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.VariationOption)
                .WithMany(x => x.Configurations)
                .HasForeignKey(x => x.VariationOptionId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
