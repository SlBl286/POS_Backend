using POS.Domain.Common.Models;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Domain.UnitAggregate;

public sealed class Unit : AggregatetRoot<UnitId, Guid>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    private Unit(UnitId id,
        string code,
        string name
    ) : base(id)
    {
        Code = code;
        Name = name;
    }

    public static Unit Create(UnitId id,
    string code,
    string name
                            )
    {
        return new Unit(UnitId.CreateUnique(), code, name);
    }

#pragma warning disable CS0618
    private Unit() { }
#pragma warning restore CS0618
}