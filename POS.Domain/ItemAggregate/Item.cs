using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.Entities;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Domain.ItemAggregate;

public sealed class Item : AggregatetRoot<ItemId, Guid>
{
    private readonly List<Barcode> _barcodes = [];
    public string Code { get; private set; }
    public string Name { get; private set; }
    public decimal? ImportPrice { get; private set; }
    public decimal RetailPrice { get; private set; }
    public decimal? WholesalePrice { get; private set; }
    public UnitId UnitId { get; private set; }
    public string? Avatar { get; private set; }
    public IReadOnlyList<Barcode> Barcodes => _barcodes.AsReadOnly();

    private Item(ItemId id,
        string code,
        string name,
        decimal? importPrice,
        decimal retailPrice,
        decimal? wholesalePrice,
        UnitId unitId,
        string avatar,
        List<Barcode> barcodes
                 ) : base(id)
    {
        Code = code;
        Name = name;
        ImportPrice = importPrice;
        RetailPrice = retailPrice;
        WholesalePrice = wholesalePrice;
        UnitId = unitId;
        Avatar = avatar;
        _barcodes = barcodes;

    }

    public static Item Create(
        ItemId id,
    string code,
    decimal? importPrice,
    string name,
    decimal retailPrice,
    decimal? wholesalePrice,
    UnitId unitId,
    string avatar,
    List<Barcode> barcodes
                            )
    {
        return new Item(id, code, name, importPrice, retailPrice, wholesalePrice, unitId, avatar, barcodes);
    }

#pragma warning disable CS0618
    private Item() { }
#pragma warning restore CS0618
}