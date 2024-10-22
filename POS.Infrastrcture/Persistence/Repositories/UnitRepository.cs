using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class UnitRepository : IUnitRepository
{
    private readonly POSDbContext _dbContext;

    public UnitRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Unit item)
    {
        var AddResult = await _dbContext.AddAsync(item);
        _dbContext.SaveChanges();
    }

    public async Task<Unit?> GetById(UnitId id)
    {
        var item = await _dbContext.Set<Unit>().FirstOrDefaultAsync(u => u.Id == id);
        return item;
    }

    public async Task<bool> ExistsAsync(UnitId Id)
    {
        var item = await _dbContext.FindAsync<Unit>(Id);
        return item is not null;
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var item = await _dbContext.Set<Unit>().FirstOrDefaultAsync(u => u.Code == code);
        return item is not null;
    }

    public async Task<List<Unit>> GetList()
    {
        return await _dbContext.Set<Unit>().ToListAsync();
    }
}
