

using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Users.Common;
using POS.Domain.Common.Errors;
using POS.Domain.UserAggregate.ValueObjects;

namespace POS.Application.Users.Queries.GetUser;

public class GetUserQueryHandler :
    IRequestHandler<GetUserQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var item = await _userRepository.GetById(UserId.Create(query.Id));
        if (item is null)
        {
            return Errors.Item.NotExsits;
        }

        return new UserResult(item);
    }
}