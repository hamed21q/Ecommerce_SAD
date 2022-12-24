using ES.Domain.Entities.ProductItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Mappings
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
        }
    }
}