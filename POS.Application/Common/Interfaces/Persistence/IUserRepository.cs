using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByUsername(string username);
    Task Add(User user);
    Task<bool> ExistsAsync(UserId Id);
    bool ExistsAsync(string username);
}