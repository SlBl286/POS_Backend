using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class ItemCategoryRepository : IItemCategoryRepository
{
    private readonly POSDbContext _dbContext;

    public ItemCategoryRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(ItemCategory item)
    {
        var AddResult = await _dbContext.AddAsync(item);
        _dbContext.SaveChanges();
    }
    public async Task Update(ItemCategory item)
    {
        var UpdateResult = _dbContext.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ItemCategory?> GetById(ItemCategoryId id)
    {
        var item = await _dbContext.Set<ItemCategory>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        return item;
    }

    public async Task<bool> ExistsAsync(ItemCategoryId id)
    {
        var item = await _dbContext.Set<ItemCategory>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        return item is not null;
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var item = await _dbContext.Set<ItemCategory>().FirstOrDefaultAsync(u => u.Code == code);
        return item is not null;
    }

    public async Task<List<ItemCategory>> GetList()
    {
        return await _dbContext.Set<ItemCategory>().ToListAsync();
    }

    public async Task AddRange(List<ItemCategory> entities)
    {
        await _dbContext.AddRangeAsync(entities);
    }

    public async Task Delete(List<ItemCategory> entities)
    {
        _dbContext.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(List<ItemCategoryId> ids)
    {
        var entities = await _dbContext.Set<ItemCategory>().Where(ic => ids.Contains(ic.Id)).ToListAsync();
        _dbContext.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }
}
