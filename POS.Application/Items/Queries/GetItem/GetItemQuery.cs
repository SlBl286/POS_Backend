using ErrorOr;
using MediatR;
using POS.Application.Items.Common;

namespace POS.Application.Items.Queries.GetItem;

public record GetItemQuery(
    Guid Id
): IRequest<ErrorOr<ItemResult>>;