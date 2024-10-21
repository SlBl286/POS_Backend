using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UnitAggregate.ValueObjects;
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
        builder.Property(m => m.Code)
            .HasMaxLength(100);
        builder.Property(m => m.Name)
            .HasMaxLength(255);
        builder.Property(m => m.Avatar)
            .HasMaxLength(100);
        builder.Property(m => m.ImportPrice);
        builder.Property(m => m.RetailPrice);
        builder.Property(m => m.WholesalePrice);
         builder.Property(m => m.UnitId)
            .HasConversion(
                id =>  id!.Value,
                value => UnitId.CreateNullable(value)
            );
        builder
       .HasIndex(u => u.Code)
       .IsUnique();

    }
}