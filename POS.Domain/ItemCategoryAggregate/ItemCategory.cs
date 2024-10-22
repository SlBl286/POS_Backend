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
        List<ItemItemCategory> items,
        DateTime? updatedAt,
        DateTime? createdAt
        ) : base(id)
    {
        Code = code;
        Name = name;
        Description = description;
        _items = items;
        if(updatedAt is not null)
            UpdatedAt = updatedAt.Value;
        if(createdAt is not null)
            CreatedAt = createdAt.Value;            
    }

    public static ItemCategory Create(ItemCategoryId id,
    string code,
    string name,
    string? description,
    List<ItemItemCategory> items,DateTime? updatedAt = null,DateTime? createdAt = null)
    {
        return new ItemCategory(id, code, name, description, items,updatedAt,createdAt);
    }

#pragma warning disable CS0618
    private ItemCategory() { }
#pragma warning restore CS0618
}