using ErrorOr;
using MediatR;
using POS.Application.Items.Common;
using POS.Application.Users.Common;

namespace POS.Application.Users.Queries.GetUser;

public record GetUserQuery(
    Guid Id
) : IRequest<ErrorOr<UserResult>>;