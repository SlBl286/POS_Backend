using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.Entities;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UnitAggregate.ValueObjects;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class ItemConfigurations : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        ConfigureItemTable(builder);
        ConfigureBarcodesTable(builder);

    }

    private void ConfigureBarcodesTable(EntityTypeBuilder<Item> builder)
    {
        builder.OwnsMany(i => i.Barcodes, sb =>
        {
            sb.ToTable("Barcodes");
            sb.WithOwner().HasForeignKey("ItemId");

            sb.HasKey(nameof(Barcode.Id), "ItemId");

            sb.Property(b => b.Id)
                .HasColumnName("BarcodeId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BarcodeId.Create(value)
            );
            sb.Property(b => b.Code).HasMaxLength(100);

        });

        builder.Metadata.FindNavigation(nameof(Item.Barcodes))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureItemTable(EntityTypeBuilder<Item> builder)
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
               id => id.Value,
               value => UnitId.Create(value)
           ).IsRequired(false);

        builder
       .HasIndex(u => u.Code)
       .IsUnique();

    }
}