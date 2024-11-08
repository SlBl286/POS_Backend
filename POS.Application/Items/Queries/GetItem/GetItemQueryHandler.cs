

using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Items.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemAggregate.ValueObjects;

namespace POS.Application.Items.Queries.GetItem;

public class GetItemQueryHandler :
    IRequestHandler<GetItemQuery, ErrorOr<ItemResult>>
{
    private readonly IItemRepository _itemCategoryRepository;

    public GetItemQueryHandler(IItemRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }

    public async Task<ErrorOr<ItemResult>> Handle(GetItemQuery query, CancellationToken cancellationToken)
    {
        var item = await _itemCategoryRepository.GetById(ItemId.Create(query.Id));
        if (item is null)
        {
            return Errors.Item.NotExsits;
        }

        return new ItemResult(item);
    }
}