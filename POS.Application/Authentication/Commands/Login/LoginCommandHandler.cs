

using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Common.Interfaces.Services;
using POS.Domain.Common.Errors;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Application.Authentication.Commands.Login;

public class LoginCommandHandler :
    IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IHashStringService _hashStringService;

    public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IHashStringService hashStringService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _hashStringService = hashStringService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsername(query.Username);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!_hashStringService.VerifyPassword(query.Password, user.HashedPassword, Convert.FromBase64String(user.Salt)))
        {
            return Errors.Authentication.InvalidCredentials;
        }
          var userUpdate = User.Create(user.Id,
                                     user.FirstName,
                                     user.LastName,
                                     user.Username,
                                     user.Email,
                                     user.PhoneNumber,
                                     user.Birthday,
                                     user.Avatar,
                                     user.Address,
                                     user.HashedPassword,
                                     user.Salt,
                                     RefreshToken.Create(DateTime.UtcNow.AddDays(7)));
        await _userRepository.Update(userUpdate);
        var token = _jwtTokenGenerator.GenerateToken(userUpdate);
        return new AuthenticationResult(userUpdate, token);
    }
}