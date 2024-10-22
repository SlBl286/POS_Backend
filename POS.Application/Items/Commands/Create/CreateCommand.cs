using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Items.Common;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Application.Items.Commands.Create;

public record CreateCommand(
    string Code,
    string Name,
    ItemCategoryId CategoryId
) : IRequest<ErrorOr<ItemResult>>;