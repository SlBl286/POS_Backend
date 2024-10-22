using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IItemCategoryRepository
{
    Task<ItemCategory?> GetById(ItemCategoryId Id);
    Task<List<ItemCategory>> GetList();

    Task Add(ItemCategory entity);
    Task AddRange(List<ItemCategory> entities);

    Task Update(ItemCategory entity);
    Task Delete(List<ItemCategory> entities);
    Task Delete(List<ItemCategoryId> ids);


    Task<bool> ExistsAsync(ItemCategoryId Id);
    Task<bool> ExistsAsync(string code);

}