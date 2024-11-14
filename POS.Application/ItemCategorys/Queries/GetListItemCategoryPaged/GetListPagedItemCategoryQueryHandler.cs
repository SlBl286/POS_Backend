

using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.ItemCategorys.Common;
using POS.Domain.Common.Errors;

namespace POS.Application.ItemCategorys.Queries.GetListItemCategoryPaged;

public class GetListPagedItemCategoryQueryHandler :
    IRequestHandler<GetListPagedItemCategoryQuery, ErrorOr<ItemCategoriesPagedResult>>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;

    public GetListPagedItemCategoryQueryHandler(IItemCategoryRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }

    public async Task<ErrorOr<ItemCategoriesPagedResult>> Handle(GetListPagedItemCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _itemCategoryRepository.GetListPage(request.Keyword, request.Page, request.PageSize);
        var total = (await _itemCategoryRepository.GetList()).Count();
        if (categories is null)
        {
            return Errors.ItemCategory.NotExsits;
        }

        return new ItemCategoriesPagedResult(categories.ConvertAll(c => new ItemCategoryResult(c)), total, (int)Math.Ceiling((double)total / request.PageSize), request.Page);

    }
}