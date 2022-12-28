using ES.Domain.Entities.Users.UserAddress;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ES.Infructructure.EfCore.Mappings.Users
{
    public class UserAddressMapping : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UnitNumber).IsRequired(); 
            builder.Property(x => x.Street).IsRequired();
            builder.Property(x => x.AddressLine1).IsRequired();
            builder.Property(x => x.AddressLine2).IsRequired();
            builder.Property(x => x.PostalCode).IsRequired();
            builder.Property(x => x.city).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
        }
    }
}
