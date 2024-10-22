using FluentValidation;

namespace POS.Application.ItemCategorys.Commands.PatchItemCategory;

public class PatchItemCategoryCommandValidator : AbstractValidator<PatchItemCategoryCommand>
{
    public PatchItemCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}