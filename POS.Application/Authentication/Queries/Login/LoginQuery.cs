using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;

namespace POS.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Username,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;