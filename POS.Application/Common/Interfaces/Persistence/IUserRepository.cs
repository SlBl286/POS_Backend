using POS.Domain.ItemAggregate;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User,UserId>
{
    Task<User?> GetUserByUsername(string username);
     Task<bool> ExistsAsync(string username);
}