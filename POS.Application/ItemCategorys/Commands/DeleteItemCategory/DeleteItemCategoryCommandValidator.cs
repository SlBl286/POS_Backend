using FluentValidation;
using POS.Application.ItemCategorys.Commands.PatchItemCategory;

namespace POS.Application.ItemCategorys.Commands.DeleteItemCategory;

public class DeleteItemCategoryCommandValidator : AbstractValidator<DeleteItemCategoryCommand>
{
    public DeleteItemCategoryCommandValidator()
    {
        RuleFor(x => x.Ids).NotEmpty();
    }
}