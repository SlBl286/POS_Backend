using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Items.Commands.CreateItem;
using POS.Application.Items.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.Entities;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Items.Commands.UpdateItem;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ErrorOr<ItemResult>>
{
    private readonly IItemRepository _itemRepository;
    public UpdateItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<ErrorOr<ItemResult>> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetById(ItemId.Create(command.Id));
        if (item is null)
        {
            return Errors.Item.NotExsits;
        }
        var barcodes = command.Barcodes?.ConvertAll(b => Barcode.Create(b.Code)).ToList();
        var itemUpdated = Item.Create(ItemId.CreateUnique(),
         command.Code ?? item.Code,
         command.Name ?? item.Name,
         command.ImportPrice ?? item.ImportPrice,
         command.RetailPrice ?? item.RetailPrice,
         command.WholesalePrice ?? item.WholesalePrice,
         command.UnitId is null ? item.UnitId : UnitId.Create(command.UnitId),
         command.Avatar ?? item.Avatar,
         command.Description ?? item.Description,
         barcodes ?? [.. item.Barcodes]
         );
        await _itemRepository.Update(item);
        return new ItemResult(item);
    }
}