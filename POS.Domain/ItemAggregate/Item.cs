using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.Entities;
using POS.Domain.ItemAggregate.ValueObjects;

namespace POS.Domain.ItemAggregate;

public sealed class Item : AggregatetRoot<ItemId, Guid>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public decimal? ImportPrice { get; private set; }
    public decimal RetailPrice { get; private set; }
    public decimal? WholesalePrice { get; private set; }
    public Unit? Unit { get; private set; }
    public string? Avatar { get; private set; }
    private Item(ItemId id,
        string code,
        string name,
        decimal? importPrice,
        decimal retailPrice,
        decimal? wholesalePrice,
        Unit? unit,
        string avatar
                 ) : base(id)
    {
        Code = code;
        Name = name;
        ImportPrice = importPrice;
        RetailPrice = retailPrice;
        WholesalePrice = wholesalePrice;
        Unit = unit;    
        Avatar = avatar;

    }

    public static Item Create(ItemId id,
    string code,
    decimal? importPrice,
    string name,
    decimal retailPrice,
    decimal? wholesalePrice,
    Unit? unit,
    string avatar
                            )
    {
        return new Item(ItemId.CreateUnique(), code, name, importPrice, retailPrice, wholesalePrice, unit, avatar);
    }

#pragma warning disable CS0618
    private Item() { }
#pragma warning restore CS0618
}