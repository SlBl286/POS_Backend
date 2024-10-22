using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.ItemCategorys.Common;
using POS.Domain.Common.Errors;
using POS.Domain.ItemCategoryAggregate;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
namespace POS.Application.ItemCategorys.Commands.CreateItemCategory;

public class CreateItemCategoryCommandHandler : IRequestHandler<CreateItemCategoryCommand, ErrorOr<ItemCategoryResult>>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;
    public CreateItemCategoryCommandHandler(IItemCategoryRepository itemCategoryRepository)
    {
        _itemCategoryRepository = itemCategoryRepository;
    }

    public async Task<ErrorOr<ItemCategoryResult>> Handle(CreateItemCategoryCommand request, CancellationToken cancellationToken)
    {
        
        if(await _itemCategoryRepository.ExistsAsync(request.Code)){
           return Errors.ItemCategory.DuplicateCode;
        }

        var itemCategory = ItemCategory.Create(ItemCategoryId.CreateUnique(),request.Code,request.Name,request.Description,[]);

        await _itemCategoryRepository.Add(itemCategory);

        return new ItemCategoryResult(itemCategory);
    }
}