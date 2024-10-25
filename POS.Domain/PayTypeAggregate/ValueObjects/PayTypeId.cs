using POS.Domain.Common.Models;

namespace POS.Domain.PayTypeAggregate.ValueObjects;

public sealed class PayTypeId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
     private PayTypeId(Guid value){
        Value = value;
    }
    public static PayTypeId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static PayTypeId Create(Guid value){
        return new(value);
    }
      public static PayTypeId Create(string value){
        return new(Guid.Parse(value));
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}