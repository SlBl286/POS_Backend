using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.ItemAggregate;
using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class UnitConfigurations : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        ConfigureUnitTable(builder);

    }
    private void ConfigureUnitTable(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UnitId.Create(value)
            );
        builder.Property(m => m.Code)
            .HasMaxLength(100);
        builder.Property(m => m.Name)
            .HasMaxLength(255);
        builder
       .HasIndex(u => u.Code)
       .IsUnique();

    }
}