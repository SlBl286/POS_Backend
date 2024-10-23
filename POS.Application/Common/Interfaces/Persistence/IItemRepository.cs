using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IItemRepository :IRepository<Item,ItemId>
{
    Task<bool> ExistsAsync(string code);
    Task<bool> ExistsAsync(List<string> barcodeIds);
}