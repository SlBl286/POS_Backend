using ErrorOr;
using MediatR;
using POS.Application.ItemCategorys.Common;

namespace POS.Application.ItemCategorys.Queries.GetListItemCategoryPaged;

public record GetListPagedItemCategoryQuery(
    string? Keyword,
    int Page,
    int PageSize
) : IRequest<ErrorOr<ItemCategoriesPagedResult>>;