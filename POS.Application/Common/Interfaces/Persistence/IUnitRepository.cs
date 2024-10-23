using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IUnitRepository : IRepository<Unit,UnitId>
{
        Task<bool> ExistsAsync(string code);

}