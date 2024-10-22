using FluentValidation;
using POS.Application.Authentication.Commands.Register;

namespace POS.Application.ItemCategorys.Commands.CreateItemCategory;

public class CreateItemCategoryCommandValidator : AbstractValidator<CreateItemCategoryCommand>
{
    public CreateItemCategoryCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();

    }
}