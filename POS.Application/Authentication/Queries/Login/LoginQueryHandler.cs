

using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Authentication.Queries.Login;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Common.Interfaces.Services;
using POS.Domain.Common.Errors;

namespace POS.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IHashStringService _hashStringService;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IHashStringService hashStringService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _hashStringService = hashStringService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsername(query.Username);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (_hashStringService.VerifyPassword(query.Password, user.HashedPassword, Convert.FromBase64String(user.Salt)))
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}