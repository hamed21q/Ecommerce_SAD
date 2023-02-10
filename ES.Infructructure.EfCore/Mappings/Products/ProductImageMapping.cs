using ES.Domain.Entities.Products.ProductItemImage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ES.Infructructure.EfCore.Mappings.Products
{
    public class ProductImageMapping : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Image);

            builder.HasOne(x => x.ProductItem).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductItemId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
