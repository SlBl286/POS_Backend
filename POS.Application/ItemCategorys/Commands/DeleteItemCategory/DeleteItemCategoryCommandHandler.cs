using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.ItemCategorys.Commands.PatchItemCategory;
using POS.Application.ItemCategorys.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
namespace POS.Application.ItemCategorys.Commands.DeleteItemCategory;

public class DeleteItemCategoryCommandHandler : IRequestHandler<DeleteItemCategoryCommand, ErrorOr<bool>>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;
    public DeleteItemCategoryCommandHandler(IItemCategoryRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }


    public async Task<ErrorOr<bool>> Handle(DeleteItemCategoryCommand command, CancellationToken cancellationToken)
    {
        await _itemCategoryRepository.Delete(command.Ids.ConvertAll(id => ItemCategoryId.Create(id)));

        return true;
    }
}