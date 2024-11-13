using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.GuestAggregate;
using POS.Domain.GuestAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Configurations;

public class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestTable(builder);

    }
    private void ConfigureGuestTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value)
            );
        builder.Property(m => m.Name)
            .HasMaxLength(255);
        builder.Property(m => m.PhoneNumber)
            .HasMaxLength(100);
        builder.Property(m => m.Email)
            .HasMaxLength(100);
        builder.Property(m => m.PhoneNumber)
            .HasMaxLength(100);
        builder.Property(m => m.YearOfBirth);
        builder.Property(m => m.Gender);
        builder.Property(m => m.Address)
            .HasMaxLength(int.MaxValue);
        builder
       .HasIndex(u => u.Code)
       .IsUnique();

            builder.HasGeneratedTsVectorColumn(g=>g.SearchVector,"english",
        g=> new {g.Code, g.Name,g.Address}
       ).HasIndex(ic=> ic.SearchVector)
       .HasMethod("GIN");
    }
}