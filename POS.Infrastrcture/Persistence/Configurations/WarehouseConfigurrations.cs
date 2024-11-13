using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;
using POS.Domain.WarehouseAggregate;
using POS.Domain.WarehouseAggregate.Entities;
using POS.Domain.WarehouseAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class WarehouseConfigurrations : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        ConfigureWarehouseTable(builder);
        ConfigureWarehouseItemTable(builder);

    }
     private void ConfigureWarehouseItemTable(EntityTypeBuilder<Warehouse> builder)
    {
        builder.OwnsMany(i => i.Items, sb =>
        {
            sb.ToTable("WarehouseItems");
            sb.WithOwner().HasForeignKey("WarehouseId");

            sb.HasKey(nameof(WarehouseItem.Id), "WarehouseId");

            sb.Property(b => b.Id)
                .HasColumnName("WarehouseItemId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => WarehouseItemId.Create(value)
            );
            sb.Property(b => b.ItemId)
                .HasColumnName("ItemId")
                .HasConversion(
                    id => id.Value,
                    value => ItemId.Create(value)
            );
            sb.Property(b => b.Quantity);

        });

        builder.Metadata.FindNavigation(nameof(Warehouse.Items))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureWarehouseTable(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => WarehouseId.Create(value)
            );
        builder.Property(m => m.Code)
            .HasMaxLength(100);
        builder.Property(m => m.Name)
            .HasMaxLength(255);
        builder.Property(m => m.Description)
            .HasMaxLength(255).IsRequired(false);
        builder
       .HasIndex(u => u.Code)
       .IsUnique();

        builder.HasGeneratedTsVectorColumn(wh=>wh.SearchVector,"english",
        wh=> new {wh.Code, wh.Name, wh.Description}
       ).HasIndex(ic=> ic.SearchVector)
       .HasMethod("GIN");

    }
}