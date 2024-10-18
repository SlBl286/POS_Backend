using POS.Domain.UserAggregate;

namespace POS.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);