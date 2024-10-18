using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.Common.Errors;
using POS.Domain.UserAggregate;

namespace POS.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //Check if user already exists
        if (_userRepository.ExistsAsync(command.Username))
        {
            return Errors.User.DuplicateUserName;
        }

        //Create user (generate unique ID)
        var user = User.Create(command.FirstName, command.LastName,command.Username, command.Email, command.PhoneNumber, command.Birthday, command.Avatar, command.Address, command.Password);
        await _userRepository.Add(user);
        //Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}