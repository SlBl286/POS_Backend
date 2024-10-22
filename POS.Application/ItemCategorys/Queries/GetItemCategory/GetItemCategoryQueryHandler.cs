

using ErrorOr;
using MediatR;
using POS.Application.Authentication.Common;
using POS.Application.Authentication.Queries.Login;
using POS.Application.Common.Interfaces.Authentication;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Common.Interfaces.Services;
using POS.Application.ItemCategorys.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemCategoryAggregate.ValueObjects;

namespace POS.Application.ItemCategorys.Queries.GetItemCategory;

public class GetItemCategoryQueryHandler :
    IRequestHandler<GetItemCategoryQuery, ErrorOr<ItemCategoryResult>>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;

    public GetItemCategoryQueryHandler(IItemCategoryRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }

    public async Task<ErrorOr<ItemCategoryResult>> Handle(GetItemCategoryQuery query, CancellationToken cancellationToken)
    {
        var category = await _itemCategoryRepository.GetById(ItemCategoryId.Create(query.Id));
        if (category is null)
        {
            return Errors.ItemCategory.NotExsits;
        }

        return new ItemCategoryResult(category);
    }
}