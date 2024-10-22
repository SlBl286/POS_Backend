using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Domain.ItemCategoryAggregate.Entities;
public sealed class ItemItemCategory : Entity<ItemItemCategoryId>
{
    public ItemId ItemId { get;private set; }

    public decimal Quantity { get;private set; }
    private ItemItemCategory(ItemItemCategoryId id,ItemId itemId,decimal quantity ) : base(id)
    {
        ItemId = itemId;
        Quantity = quantity;
    }

        
    public static ItemItemCategory Create(ItemItemCategoryId id,ItemId itemId,decimal quantity)
    {
        return new ItemItemCategory(id,itemId,quantity);
    }

#pragma warning disable CS0618
    private ItemItemCategory() { }
#pragma warning restore CS0618
}   