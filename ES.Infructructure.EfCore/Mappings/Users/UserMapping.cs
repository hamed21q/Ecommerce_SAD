﻿using ES.Domain.Entities.Users.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ES.Infructructure.EfCore.Mappings.Users
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EmailAddress);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Password);
            builder.Property(x => x.IsDeleted); 
            builder.Property(x => x.PasswordSalt);


            builder.HasOne(x => x.Address).WithMany(x => x.Users).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Role).WithMany(x =>x.Users).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
