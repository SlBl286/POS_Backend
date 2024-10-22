using ErrorOr;
using MediatR;
using POS.Application.ItemCategorys.Common;

namespace POS.Application.ItemCategorys.Commands.CreateItemCategory;

public record CreateItemCategoryCommand(
    string Code,
    string Name,
    string? Description
) : IRequest<ErrorOr<ItemCategoryResult>>;