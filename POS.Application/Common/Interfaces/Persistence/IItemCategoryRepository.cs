using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IItemCategoryRepository : IRepository<ItemCategory,ItemCategoryId>
{
    Task<bool> ExistsAsync(string code);

}