using ErrorOr;
using MediatR;
using POS.Application.ItemCategorys.Common;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Application.ItemCategorys.Queries.GetItemCategory;

public record GetItemCategoryQuery(
    Guid Id
) : IRequest<ErrorOr<ItemCategoryResult>>;