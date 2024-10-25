using Microsoft.EntityFrameworkCore;
using POS.Domain.BillAggregate;
using POS.Domain.Common.Models;
using POS.Domain.GuestAggregate;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.UnitAggregate;
using POS.Domain.UserAggregate;
using POS.Domain.WarehouseAggregate;
using POS.Infrastrcture.Persistence.Interceptors;

namespace POS.Infrastrcture.Persistence;

public class POSDbContext : DbContext
{
    private PublishDomainEventsInterceptors _publishDomainEventsInterceptors;
    private CreatedUpdatedAtInterceptors _createdUpdatedAtInterceptors;
    public POSDbContext(DbContextOptions<POSDbContext> options, PublishDomainEventsInterceptors publishDomainEventsInterceptors, CreatedUpdatedAtInterceptors createdUpdatedAtInterceptors) : base(options)
    {
        _publishDomainEventsInterceptors = publishDomainEventsInterceptors;
        _createdUpdatedAtInterceptors = createdUpdatedAtInterceptors;
    }

    public DbSet<User> Users { get; } = null!;
    public DbSet<Item> Items { get; } = null!;
    public DbSet<ItemCategory> ItemCategories { get; } = null!;
    public DbSet<Unit> Units { get; } = null!;
    public DbSet<Warehouse> Warehouses { get; } = null!;
    public DbSet<Bill> Bills { get; } = null!;
    public DbSet<Guest> Guests { get; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Ignore<List<IDomainEvent>>()
        .ApplyConfigurationsFromAssembly(typeof(POSDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptors);
        optionsBuilder.AddInterceptors(_createdUpdatedAtInterceptors);

        base.OnConfiguring(optionsBuilder);
    }

}