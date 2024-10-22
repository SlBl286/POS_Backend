using ErrorOr;
using MediatR;
using POS.Application.ItemCategorys.Common;

namespace POS.Application.ItemCategorys.Commands.PatchItemCategory;

public record PatchItemCategoryCommand(
    Guid Id,
    string? Code,
    string? Name,
    string? Description
) : IRequest<ErrorOr<ItemCategoryResult>>;