using POS.Domain.UserAggregate;

namespace POS.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}