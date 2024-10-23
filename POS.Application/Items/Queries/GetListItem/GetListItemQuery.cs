using ErrorOr;
using MediatR;
using POS.Application.Items.Common;

namespace POS.Application.Items.Queries.GetListItem;

public record GetListItemQuery(
    string? Keyword
): IRequest<ErrorOr<List<ItemResult>>>;