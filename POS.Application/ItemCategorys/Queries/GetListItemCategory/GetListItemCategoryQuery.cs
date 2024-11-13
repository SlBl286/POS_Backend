using ErrorOr;
using MediatR;
using POS.Application.ItemCategorys.Common;

namespace POS.Application.ItemCategorys.Queries.GetListItemCategory;

public record GetListItemCategoryQuery(
    string? Keyword,
    int Page,
    int PageSize
): IRequest<ErrorOr<ItemCategoriesResult>>;