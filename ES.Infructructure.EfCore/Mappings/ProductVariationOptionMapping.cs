using ES.Domain.Entities.ProductVariationOption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Mappings
{
    public class ProductVariationOptionMapping : IEntityTypeConfiguration<ProductVariationOption>
    {
        public void Configure(EntityTypeBuilder<ProductVariationOption> builder)
        {
            builder.ToTable("ProductVariationOptions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value);
            builder.HasOne(x => x.Variation)
                .WithMany(x => x.ProductVariationOptions)
                .HasForeignKey(x => x.VariationId);
        }
    }
}
