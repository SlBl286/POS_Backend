using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;

namespace POS.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber,
    DateTime Birthday,
    string? Avatar,
    string? Address,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;