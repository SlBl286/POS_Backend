using Microsoft.EntityFrameworkCore;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Infrastrcture.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly POSDbContext _dbContext;

    public UserRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        var a = await _dbContext.AddAsync(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByUsername(string username)
    {
        var user = _dbContext.Set<User>().Where(u => u.Username == username).FirstOrDefault();
        return user;
    }

     public bool ExistsAsync(string username)
    {
        if(_dbContext.Set<User>() != null){

        var user =  _dbContext.Set<User>().Where(u => u.Username == username).FirstOrDefault();
        return user is not null;
        }
        else return false;
    }
      public async  Task<bool> ExistsAsync(UserId Id)
    {
        var user = await _dbContext.FindAsync<User>(Id.Value);
        return user is not null;
    }

}
