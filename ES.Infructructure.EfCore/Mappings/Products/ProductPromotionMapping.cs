using ES.Domain.Entities.Products.ProductPromotion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ES.Infructructure.EfCore.Mappings.Products
{
    public class ProductPromotionMapping : IEntityTypeConfiguration<ProductPromotion>
    {
        public void Configure(EntityTypeBuilder<ProductPromotion> builder)
        {
            builder.ToTable("Promotions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.DiscountRate);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);

        }

    }
}
