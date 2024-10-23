using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class UnitRepository :Repository<Unit,UnitId>, IUnitRepository
{

    public UnitRepository(POSDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var item = await _dbContext.Set<Unit>().FirstOrDefaultAsync(u => u.Code == code);
        return item is not null;
    }
}
