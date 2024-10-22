using ErrorOr;
using MediatR;

namespace POS.Application.ItemCategorys.Commands.DeleteItemCategory;

public record DeleteItemCategoryCommand(
    List<Guid> Ids
) : IRequest<ErrorOr<bool>>;