using Microsoft.EntityFrameworkCore;
using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate;
using POS.Domain.UserAggregate;
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

    public DbSet<User> Users { get;} =  null!;
    public DbSet<Item> Items { get;} =  null!;


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