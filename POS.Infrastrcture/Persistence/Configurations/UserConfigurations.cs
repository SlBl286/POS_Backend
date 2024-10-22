using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.ItemAggregate;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);

    }
    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );
        builder.Property(m => m.LastName)
            .HasMaxLength(100);
        builder.Property(m => m.FirstName)
            .HasMaxLength(100);
        builder.Property(m => m.Username)
            .HasMaxLength(100);
        builder.Property(m => m.Email)
            .HasMaxLength(100);
        builder.Property(m => m.PhoneNumber)
            .HasMaxLength(100);
        builder.Property(m => m.Birthday);
        builder.Property(m => m.Address)
            .HasMaxLength(int.MaxValue);
        builder.Property(m => m.Avatar)
            .HasMaxLength(255);
        builder.Property(m => m.Salt)
            .HasMaxLength(255);
        builder.Property(m => m.HashedPassword)
            .HasMaxLength(255);
        builder
       .HasIndex(u => u.Username)
       .IsUnique();

    }
}