using POS.Domain.Common.Models;

namespace POS.Domain.PayTypeAggregate.ValueObjects;

public sealed class PayTypeId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

     public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}