using POS.Domain.Common.Models;

namespace POS.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    public override Guid Value { get ;protected set;}

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}