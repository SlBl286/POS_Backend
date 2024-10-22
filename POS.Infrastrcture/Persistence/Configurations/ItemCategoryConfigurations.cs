using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.Entities;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.Entities;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
using POS.Domain.UnitAggregate.ValueObjects;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class ItemCategoryConfigurations : IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        ConfigureItemCategoryTable(builder);
        ConfigureItemItemCategoryTable(builder);

    }
    private void ConfigureItemItemCategoryTable(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.OwnsMany(i => i.Items, sb =>
        {
            sb.ToTable("ItemItemCategorys");

            sb.WithOwner().HasForeignKey("ItemCategoryId");

            sb.HasKey(nameof(ItemItemCategory.Id), "ItemCategoryId");
            sb.Property(s => s.Id)
                .HasColumnName("ItemItemCategoryId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ItemItemCategoryId.Create(value)
                );

            sb.Property(d => d.ItemId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ItemId.Create(value)
                );
            sb.Property(d => d.Quantity).HasDefaultValue(0);
        });

        builder.Metadata.FindNavigation(nameof(ItemCategory.Items))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureItemCategoryTable(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.ToTable("ItemCategorys");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ItemCategoryId.Create(value)
            );
        builder.Property(m => m.Code)
            .HasMaxLength(100);
        builder.Property(m => m.Name)
            .HasMaxLength(255);
        builder.Property(m => m.Description);
        builder
       .HasIndex(u => u.Code)
       .IsUnique();

    }
}