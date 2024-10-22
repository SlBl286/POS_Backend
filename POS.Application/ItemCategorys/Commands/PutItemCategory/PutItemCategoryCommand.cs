using ErrorOr;
using MediatR;
using POS.Application.ItemCategorys.Common;

namespace POS.Application.ItemCategorys.Commands.PutItemCategory;

public record PutItemCategoryCommand(
    Guid Id,
    string Code,
    string Name,
    string? Description
) : IRequest<ErrorOr<ItemCategoryResult>>;