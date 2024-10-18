
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace CA.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);

    }

    // private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    // {
    //     builder.OwnsMany(m => m.MenuReviewIds, rb =>
    //     {
    //         rb.ToTable("MenuReviewIds");

    //         rb.WithOwner().HasForeignKey("MenuId");

    //         rb.HasKey("Id");

    //         rb.Property(d => d.Value)
    //             .HasColumnName("ReviewId")
    //             .ValueGeneratedNever();
    //     });

    //     builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
    //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    // }

    // private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    // {
    //     builder.OwnsMany(m => m.DinnerIds, db =>
    //     {
    //         db.ToTable("MenuDinnerIds");

    //         db.WithOwner().HasForeignKey("MenuId");

    //         db.HasKey("Id");

    //         db.Property(d => d.Value)
    //             .HasColumnName("DinnerId")
    //             .ValueGeneratedNever();
    //     });

    //     builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
    //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    // }

    // private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    // {
    //     builder.OwnsMany(m => m.Sections, sb =>
    //     {
    //         sb.ToTable("MenuSections");
    //         sb.WithOwner().HasForeignKey("MenuId");

    //         sb.HasKey(nameof(MenuSection.Id), "MenuId");

    //         sb.Property(s => s.Id)
    //             .HasColumnName("MenuSectionId")
    //             .ValueGeneratedNever()
    //             .HasConversion(
    //                 id => id.Value,
    //                 value => MenuSectionId.Create(value)
    //             );
    //         sb.Property(s => s.Name)
    //             .HasMaxLength(100);
    //         sb.Property(s => s.Description)
    //             .HasMaxLength(100);

    //         sb.OwnsMany(s => s.Items, ib =>
    //         {
    //             ib.ToTable("MenuItems");
    //             ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

    //             ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

    //             ib.Property(i => i.Id)
    //             .HasColumnName("MenuItemId")
    //             .ValueGeneratedNever()
    //             .HasConversion(
    //                 id => id.Value,
    //                 value => MenuItemId.Create(value)
    //             );
    //             ib.Property(i => i.Name)
    //                 .HasMaxLength(100);
    //             ib.Property(i => i.Description)
    //                 .HasMaxLength(100);
    //         });
    //         sb.Navigation(s => s.Items).Metadata.SetField("_items");
    //         sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    //     });

    //     builder.Metadata.FindNavigation(nameof(Menu.Sections))!
    //     .SetPropertyAccessMode(PropertyAccessMode.Field);
    // }

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
        builder
       .HasIndex(u => u.Username)
       .IsUnique();

    }
}