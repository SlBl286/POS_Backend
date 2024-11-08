using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Common.Interfaces.Services;
using POS.Domain.Common.Errors;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IHashStringService _hashStringService;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IHashStringService hashStringService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _hashStringService = hashStringService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //Check if user already exists
        if (await _userRepository.ExistsAsync(command.Username))
        {
            return Errors.User.DuplicateUserName;
        }
        var hashedPassword = _hashStringService.HashPassword(command.Password, out byte[] salt);
        //Create user (generate unique ID)
        var user = User.Create(UserId.CreateUnique(),
                                command.FirstName,
                               command.LastName,
                               command.Username,
                               command.Email,
                               command.PhoneNumber,
                               command.Birthday,
                               command.Avatar,
                               command.Address,
                               hashedPassword,
                               Convert.ToBase64String(salt),
                               RefreshToken.Create(DateTime.UtcNow.AddDays(7)));

        await _userRepository.Add(user);
        //Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}