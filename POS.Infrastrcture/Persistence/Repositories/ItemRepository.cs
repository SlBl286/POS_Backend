using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly POSDbContext _dbContext;

    public ItemRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Item item)
    {
        var AddResult = await _dbContext.AddAsync(item);
        _dbContext.SaveChanges();
    }

    public async Task<Item?> GetById(ItemId id)
    {
        var item = await _dbContext.Set<Item>().FirstOrDefaultAsync(u => u.Id == id);
        return item;
    }

    public async Task<bool> ExistsAsync(ItemId Id)
    {
        var user = await _dbContext.FindAsync<Item>(Id.Value);
        return user is not null;
    }

}
