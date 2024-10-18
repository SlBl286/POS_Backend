

using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Authentication.Queries.Login;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.Common.Errors;

namespace POS.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var user = _userRepository.GetUserByUsername(query.Username);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        if (user.HashedPassword != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}