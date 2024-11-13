using System.Linq.Expressions;
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

    public async Task<List<ItemCategory>> GetListPage(string? Keyword, int Page, int PageSize)
    {
        await Task.CompletedTask;
        var categories = _dbContext.Set<ItemCategory>()
        .Where(c => Keyword != null ? c.SearchVector.Matches(EF.Functions.PhraseToTsQuery(Keyword)) : true)
        .Skip(PageSize * Page)
        .Take(PageSize)
        .OrderByDescending(c => c.SearchVector.Rank(EF.Functions.PhraseToTsQuery(Keyword ?? "")))
        .ToList();
        return categories;
    }
}
