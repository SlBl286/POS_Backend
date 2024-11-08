using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;

namespace POS.Application.Authentication.Commands.Login;

public record LoginCommand(
    string Username,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;