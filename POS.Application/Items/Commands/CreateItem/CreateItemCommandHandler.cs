using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Items.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemAggregate;
using POS.Domain.ItemAggregate.Entities;
using POS.Domain.ItemAggregate.ValueObjects;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Items.Commands.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ErrorOr<ItemResult>>
{
    private readonly IItemRepository _itemRepository;
    public CreateItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<ErrorOr<ItemResult>> Handle(CreateItemCommand command, CancellationToken cancellationToken)
    {
        if(await _itemRepository.ExistsAsync(command.Code))
        {
            return Errors.Item.DuplicateCode;
        }
        if(await _itemRepository.ExistsAsync(command.Barcodes.ConvertAll(b=>b.Code)))
        {
            return Errors.Item.DuplicateBarcode;
        }
        var barcodes = command.Barcodes.ConvertAll(b=>Barcode.Create(b.Code)).ToList();
        var item = Item.Create(ItemId.CreateUnique(),
         command.Code,
         command.Name,
         command.ImportPrice,
         command.RetailPrice,
         command.WholesalePrice,
         UnitId.Create(command.UnitId),
         command.Avatar,
         command.Description,
         barcodes ?? []
         );
        await _itemRepository.Add(item);
        return new ItemResult(item);
    }
}