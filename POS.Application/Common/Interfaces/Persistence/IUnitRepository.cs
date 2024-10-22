using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IUnitRepository
{
    Task<Unit?> GetById(UnitId Id);
    Task Add(Unit item);
    Task<bool> ExistsAsync(UnitId Id);
    Task<bool> ExistsAsync(string code);
}