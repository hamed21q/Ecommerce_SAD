using ES.Domain.Entities.ProductVariation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Mappings
{
    public class ProductVariationMapping : IEntityTypeConfiguration<ProductVariation>
    {
        public void Configure(EntityTypeBuilder<ProductVariation> builder)
        {
            builder.ToTable("ProductVariations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasOne(x => x.Category)
                .WithMany(x => x.ProductVariations)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
