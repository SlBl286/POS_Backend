using System.Security.Cryptography.X509Certificates;
using POS.Application.Authentication.Commands.Register;
using FluentValidation;
using POS.Application.Authentication.Queries.Login;

namespace CA.Application.Authentication.Queries.Login;

public class RegisterCommandValidatior : AbstractValidator<LoginQuery>
{
    public RegisterCommandValidatior()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Tên người dùng không được bỏ trống");
        RuleFor(x => x.Password).NotEmpty();
    }
}