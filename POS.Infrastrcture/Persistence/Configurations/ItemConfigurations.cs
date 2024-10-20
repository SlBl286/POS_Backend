using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class ItemConfigurations : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        ConfigureUserTable(builder);

    }
    private void ConfigureUserTable(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ItemId.Create(value)
            );
        builder.Property(m => m.Avatar)
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
        builder
       .HasIndex(u => u.Username)
       .IsUnique();

    }
}