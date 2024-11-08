using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Items.Common;
using POS.Domain.Common.Errors;

namespace POS.Application.Items.Queries.GetListItem;

public sealed class GetListItemQueryHandler : IRequestHandler<GetListItemQuery, ErrorOr<List<ItemResult>>>
{
    private readonly IItemRepository _itemRepository;

    public GetListItemQueryHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<ErrorOr<List<ItemResult>>> Handle(GetListItemQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetList();
        if (items is null)
        {
            return Errors.Item.NotExsits;
        }

        return items.ConvertAll(c =>  new ItemResult(c)).ToList();
    }
}