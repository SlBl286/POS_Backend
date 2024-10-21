using POS.Domain.BillAggregate.Entities;
using POS.Domain.BillAggregate.ValueObjects;
using POS.Domain.Common.Models;
using POS.Domain.GuestAggregate.ValueObjects;
using POS.Domain.PayTypeAggregate.ValueObjects;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Domain.BillAggregate;

public sealed class Bill : AggregatetRoot<BillId, Guid>
{
    private readonly List<BillDetail> _details = [];

    public string Code { get; private set; } = null!;

    public string? Description { get; private set; }
    public DateTime BillTime { get; private set; }

    public GuestId? GuestId { get; private set; }

    public PayTypeId? PayTypeId { get; private set; }

    public UserId UserId { get; private set; }

    public IReadOnlyList<BillDetail> Details =>_details;

    private Bill(BillId id, string code, string? description,DateTime billTime,GuestId? guestId,PayTypeId payTypeId,UserId userId, List<BillDetail> details) : base(id)
    {
        Id =  id;
        Code = code;
        Description = description;
        BillTime = billTime;
        GuestId = guestId;
        PayTypeId = payTypeId;
        UserId = userId;
        _details = details;
    }

       public static Bill Create(string code, string? description,DateTime billTime,GuestId? guestId,PayTypeId payTypeId,UserId userId,List<BillDetail> details)
    {
        return new Bill(BillId.CreateUnique(), code,description,billTime,guestId,payTypeId,userId,details);
    }

#pragma warning disable CS0618
    private Bill() { }
#pragma warning restore CS0618
}