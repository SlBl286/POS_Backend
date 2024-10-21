using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.ValueObjects;

namespace POS.Domain.ItemAggregate.Entities;

public sealed class Barcode : Entity<BarcodeId>
{
    public string Code { get; private set; }
    private Barcode(BarcodeId id, string code) : base(id)
    {
        Code = code;
    }
    public static Barcode Create(string code)
    {
        return new Barcode(BarcodeId.CreateUnique(), code);
    }

#pragma warning disable CS0618
    private Barcode() { }
#pragma warning restore CS0618
}