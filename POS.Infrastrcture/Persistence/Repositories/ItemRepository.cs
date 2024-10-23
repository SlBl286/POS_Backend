using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class ItemRepository : Repository<Item, ItemId>, IItemRepository
{

    public ItemRepository(POSDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var item = await _dbContext.Set<Item>().FirstOrDefaultAsync(u => u.Code == code);
        return item is not null;
    }

    public async Task<bool> ExistsAsync(List<string> barcodeIds)
    {
        await Task.CompletedTask;
        return false;
    }
}
