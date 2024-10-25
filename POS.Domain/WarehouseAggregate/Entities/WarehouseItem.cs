using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.WarehouseAggregate.ValueObjects;

namespace POS.Domain.WarehouseAggregate.Entities;

public sealed class WarehouseItem : Entity<WarehouseItemId>
{
    public ItemId ItemId { get; private set; }
    public decimal Quantity { get; private set; }

    private WarehouseItem(WarehouseItemId id, ItemId itemId, decimal quantity) : base(id)
    {
        ItemId = itemId;
        Quantity = quantity;
    }


    public static WarehouseItem Create(WarehouseItemId id, ItemId itemId, decimal quantity)
    {
        return new WarehouseItem(id, itemId, quantity);
    }

#pragma warning disable CS0618
    private WarehouseItem() { }
#pragma warning restore CS0618
}