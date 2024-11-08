
using FluentValidation;

namespace POS.Application.Authentication.Commands.Refresh;

public class RefreshQueryValidatior : AbstractValidator<RefreshCommand>
{
    public RefreshQueryValidatior()
    {
    }
}