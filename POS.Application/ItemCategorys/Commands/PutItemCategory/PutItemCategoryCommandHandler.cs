using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.ItemCategorys.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
namespace POS.Application.ItemCategorys.Commands.PutItemCategory;

public class PutItemCategoryCommandHandler : IRequestHandler<PutItemCategoryCommand, ErrorOr<ItemCategoryResult>>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;
    public PutItemCategoryCommandHandler(IItemCategoryRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }


    public async Task<ErrorOr<ItemCategoryResult>> Handle(PutItemCategoryCommand command, CancellationToken cancellationToken)
    {
        var itemCategory = await _itemCategoryRepository.GetById(ItemCategoryId.Create(command.Id));

        if (itemCategory is null)
        {
            return Errors.ItemCategory.NotExsits;
        }

        var itemCategoryUpdated = ItemCategory.Create(ItemCategoryId.Create(command.Id), command.Code, command.Name, command.Description, [], createdAt: itemCategory.CreatedAt);

        await _itemCategoryRepository.Update(itemCategoryUpdated);

        return new ItemCategoryResult(itemCategoryUpdated);
    }
}