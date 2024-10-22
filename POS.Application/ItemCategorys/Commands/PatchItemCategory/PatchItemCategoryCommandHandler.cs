using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.ItemCategorys.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
namespace POS.Application.ItemCategorys.Commands.PatchItemCategory;

public class PatchItemCategoryCommandHandler : IRequestHandler<PatchItemCategoryCommand, ErrorOr<ItemCategoryResult>>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;
    public PatchItemCategoryCommandHandler(IItemCategoryRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }


    public async Task<ErrorOr<ItemCategoryResult>> Handle(PatchItemCategoryCommand command, CancellationToken cancellationToken)
    {
        var itemCategory = await _itemCategoryRepository.GetById(ItemCategoryId.Create(command.Id));

        if (itemCategory is null)
        {
            return Errors.ItemCategory.NotExsits;
        }
        var itemCategoryUpdated = ItemCategory.Create(
            ItemCategoryId.Create(command.Id),
            command.Code ?? itemCategory.Code,
            command.Name ?? itemCategory.Name,
            command.Description ?? itemCategory.Description,
            [],
            createdAt: itemCategory.CreatedAt);

        await _itemCategoryRepository.Update(itemCategoryUpdated);

        return new ItemCategoryResult(itemCategoryUpdated);
    }
}