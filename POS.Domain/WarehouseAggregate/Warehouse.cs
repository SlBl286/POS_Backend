using POS.Domain.Common.Models;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
using POS.Domain.WarehouseAggregate.Entities;
using POS.Domain.WarehouseAggregate.ValueObjects;

namespace POS.Domain.WarehouseAggregate;

public sealed class Warehouse : AggregatetRoot<WarehouseId, Guid>
{
    private readonly List<WarehouseItem> _items = [];
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public IReadOnlyList<WarehouseItem> Items => _items.AsReadOnly();
    private Warehouse(WarehouseId id,
        string code,
        string name,
        string? description,
        List<WarehouseItem> items) : base(id)
    {
        Code = code;
        Name = name;
        Description = description;
        _items = items;
    }

    public static Warehouse Create(ItemCategoryId id,
    string code,
    string name,
    string? description,
    List<WarehouseItem> items)
    {
        return new Warehouse(WarehouseId.CreateUnique(), code, name, description, items);
    }

#pragma warning disable CS0618
    private Warehouse() { }
#pragma warning restore CS0618
}