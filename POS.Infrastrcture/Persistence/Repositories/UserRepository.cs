using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.ItemAggregate;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class UserRepository : Repository<User, UserId>, IUserRepository
{

    public UserRepository(POSDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsAsync(string username)
    {
        var item = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        return item is not null;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        var user = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        return user;
    }

}
