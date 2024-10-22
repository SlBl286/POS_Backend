using FluentValidation;

namespace POS.Application.ItemCategorys.Commands.PutItemCategory;

public class UpdateItemCategoryCommandValidator : AbstractValidator<PutItemCategoryCommand>
{
    public UpdateItemCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();

    }
}