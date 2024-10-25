using POS.Domain.Common.Models;

namespace POS.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private GuestId(Guid value)
    {
        Value = value;
    }
    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static GuestId Create(Guid? value)
    {
        return new(value ?? Guid.Empty);
    }
    public static GuestId Create(string value)
    {
        return new(Guid.Parse(value));
    }
}