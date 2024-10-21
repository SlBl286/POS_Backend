using POS.Domain.BillAggregate.ValueObjects;
using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate.ValueObjects;

namespace POS.Domain.BillAggregate.Entities;

public sealed class BillDetail : Entity<BillDetailId>
{
    public ItemId ItemId { get;private set; }

    public decimal Quanity { get;private set; }

    private BillDetail(BillDetailId id,ItemId itemId, decimal quanity) : base(id)
    {
        Quanity = quanity;
        ItemId = itemId;
    }


    public static BillDetail Create(ItemId itemId,decimal quanity)
    {
        return new(BillDetailId.CreateUnique(),itemId,quanity);
    }
    #pragma warning disable CS0618
    private BillDetail() { }
#pragma warning restore CS0618
}