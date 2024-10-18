using POS.Domain.ItemAggregate;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByUsername(string username);
    Task Add(User user);
    Task<bool> ExistsAsync(UserId Id);
    Task<bool> ExistsAsync(string username);
}