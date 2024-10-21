using POS.Domain.Common.Models;
using POS.Domain.ItemCategoryAggregate.Entities;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Domain.ItemCategoryAggregate;

public sealed class ItemCategory : AggregatetRoot<ItemCategoryId, Guid>
{
    private readonly List<ItemItemCategory> _items = [];
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public IReadOnlyList<ItemItemCategory> Items => _items.AsReadOnly();
    private ItemCategory(ItemCategoryId id,
        string code,
        string name,
        string? description,
        List<ItemItemCategory> items
        ) : base(id)
    {
        Code = code;
        Name = name;
        Description = description;
        _items = items;
    }

    public static ItemCategory Create(ItemCategoryId id,
    string code,
    string name,
    string? description,
    List<ItemItemCategory> items)
    {
        return new ItemCategory(ItemCategoryId.CreateUnique(), code, name,description,items);
    }

#pragma warning disable CS0618
    private ItemCategory() { }
#pragma warning restore CS0618
}