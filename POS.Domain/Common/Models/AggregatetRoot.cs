namespace POS.Domain.Common.Models;

public abstract class AggregatetRoot<TId, TIdType> : Entity<TId>
where TId : AggregateRootId<TIdType>
{
    protected AggregatetRoot(TId id) : base(id)
    {

    }


#pragma warning disable CS0618
    protected AggregatetRoot()
    {

    }
#pragma warning restore CS0618
}