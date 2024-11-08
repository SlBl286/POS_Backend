using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;

namespace POS.Application.Authentication.Commands.Refresh;

public record RefreshCommand(
    string RefreshToken
) : IRequest<ErrorOr<AuthenticationResult>>;