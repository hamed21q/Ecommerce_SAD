using ES.Domain.Entities.Products.ProductVariationOption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ES.Infructructure.EfCore.Mappings.Products
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
                .HasForeignKey(x => x.VariationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Configurations)
                .WithOne(x => x.VariationOption)
                .HasForeignKey(x => x.VariationOptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
