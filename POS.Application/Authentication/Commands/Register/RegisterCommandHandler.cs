using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Common.Interfaces.Services;
using POS.Domain.Common.Errors;
using POS.Domain.ItemAggregate;
using POS.Domain.UserAggregate;

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
        var salt = _hashStringService.GenerateSalt();
        var hashedPassword = _hashStringService.HashPassword(command.Password, salt);
        //Create user (generate unique ID)
        var user = User.Create(command.FirstName,
                               command.LastName,
                               command.Username,
                               command.Email,
                               command.PhoneNumber,
                               command.Birthday,
                               command.Avatar,
                               command.Address,
                               hashedPassword,
                               Convert.ToBase64String(salt));

        await _userRepository.Add(user);
        //Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}