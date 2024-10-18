using POS.Domain.Common.Models;

namespace CA.Domain.Common.ValueObjects;
public sealed class Rating : ValueObject
{
    public double Value { get;private set; }

    private Rating(double value)
    {
        Value = value;
    }

    public static Rating CreateNew(double value = 0)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}