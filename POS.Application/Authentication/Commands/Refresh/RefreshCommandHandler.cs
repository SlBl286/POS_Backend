

using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Common.Interfaces.Services;
using POS.Domain.Common.Errors;
using POS.Domain.UserAggregate;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Application.Authentication.Commands.Refresh;

public class RefreshCommandHandler :
    IRequestHandler<RefreshCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RefreshCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RefreshCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByRefreshToken(command.RefreshToken);
        if (user is null || user.RefreshToken.ExpireTime < DateTime.UtcNow)
        {
            return Errors.Authentication.InvalidRefreshToken;
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