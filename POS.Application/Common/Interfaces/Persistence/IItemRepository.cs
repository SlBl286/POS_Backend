using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IItemRepository
{
    Task<Item?> GetById(ItemId Id);
    Task Add(Item item);
    Task<bool> ExistsAsync(ItemId Id);
}