

using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.ItemCategorys.Common;
using POS.Application.ItemCategorys.Queries.GetItemCategory;
using POS.Domain.Common.Errors;

namespace POS.Application.ItemCategorys.Queries.GetListItemCategory;

public class GetListItemCategoryQueryHandler :
    IRequestHandler<GetListItemCategoryQuery, ErrorOr<List<ItemCategoryResult>>>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;

    public GetListItemCategoryQueryHandler(IItemCategoryRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }

    public async Task<ErrorOr<List<ItemCategoryResult>>> Handle(GetListItemCategoryQuery request, CancellationToken cancellationToken)
    {
         var categories = await _itemCategoryRepository.GetList();
        if (categories is null)
        {
            return Errors.ItemCategory.NotExsits;
        }

        return categories.ConvertAll(c =>  new ItemCategoryResult(c)).ToList();
    }
}