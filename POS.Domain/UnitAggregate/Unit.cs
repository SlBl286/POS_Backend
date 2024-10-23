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
        string name,
        DateTime? updatedAt,
        DateTime? createdAt
    ) : base(id)
    {
        Code = code;
        Name = name;
        if (updatedAt is not null)
            UpdatedAt = (DateTime)updatedAt;
        if (createdAt is not null)
            CreatedAt = (DateTime)createdAt;
    }

    public static Unit Create(UnitId id,
    string code,
    string name,
    DateTime? updatedAt = null,
    DateTime? createdAt = null
                            )
    {
        return new Unit(id, code, name, updatedAt, createdAt);
    }

#pragma warning disable CS0618
    private Unit() { }
#pragma warning restore CS0618
}