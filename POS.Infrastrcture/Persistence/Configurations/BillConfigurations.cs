using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.BillAggregate;
using POS.Domain.BillAggregate.Entities;
using POS.Domain.BillAggregate.ValueObjects;
using POS.Domain.GuestAggregate.ValueObjects;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.PayTypeAggregate.ValueObjects;
using POS.Domain.UserAggregate.ValueObjects;
using POS.Domain.WarehouseAggregate;
using POS.Domain.WarehouseAggregate.Entities;
using POS.Domain.WarehouseAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class BillConfigurations : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        ConfigureBillTable(builder);
        ConfigureBillDetailTable(builder);

    }
    private void ConfigureBillDetailTable(EntityTypeBuilder<Bill> builder)
    {
        builder.OwnsMany(i => i.Details, sb =>
        {
            sb.ToTable("BillDetails");
            sb.WithOwner().HasForeignKey("BillId");

            sb.HasKey(nameof(BillDetail.Id), "BillId");

            sb.Property(b => b.Id)
                .HasColumnName("BillDetailId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BillDetailId.Create(value)
            );
            sb.Property(b => b.ItemId)
                .HasColumnName("ItemId")
                .HasConversion(
                    id => id.Value,
                    value => ItemId.Create(value)
            );
            sb.Property(b => b.Quanity);

        });

        builder.Metadata.FindNavigation(nameof(Bill.Details))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureBillTable(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value)
            );
        builder.Property(m => m.Code)
            .HasMaxLength(100);
        builder.Property(m => m.Description)
            .HasMaxLength(255).IsRequired(false);
        builder.Property(m => m.GuestId)
            .IsRequired(false)
            .ValueGeneratedNever()
            .HasConversion(
                id => id!.Value,
                value => GuestId.Create(value)
            );
        builder.Property(m => m.PayTypeId)
           .ValueGeneratedNever()
           .HasConversion(
               id => id.Value,
               value => PayTypeId.Create(value)
           );
        builder.Property(m => m.UserId)
           .ValueGeneratedNever()
           .HasConversion(
               id => id.Value,
               value => UserId.Create(value)
           );
        builder
       .HasIndex(u => u.Code)
       .IsUnique();


        builder.HasGeneratedTsVectorColumn(b => b.SearchVector, "english",
    b => new { b.Code, b.Description }
   ).HasIndex(ic => ic.SearchVector)
   .HasMethod("GIN");
    }
}