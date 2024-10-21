using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Domain.ItemCategoryAggregate.Entities;
public sealed class ItemItemCategory : Entity<ItemItemCategoryId>
{
    public ItemId ItemId { get;private set; }
    private ItemItemCategory(ItemItemCategoryId id,ItemId itemId ) : base(id)
    {
        ItemId = itemId;
    }

        
}   