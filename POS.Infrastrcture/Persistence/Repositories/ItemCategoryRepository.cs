using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class ItemCategoryRepository : Repository<ItemCategory, ItemCategoryId>, IItemCategoryRepository
{
    public ItemCategoryRepository(POSDbContext dbContext) : base(dbContext)
    {

    }
    public async Task<bool> ExistsAsync(string code)
    {
        var item = await _dbContext.Set<ItemCategory>().FirstOrDefaultAsync(u => u.Code == code);
        return item is not null;
    }
}
