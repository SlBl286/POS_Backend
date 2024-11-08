using Mapster;
using POS.Application.Authentication.Commands.Login;
using POS.Application.Authentication.Commands.Refresh;
using POS.Application.Authentication.Commands.Register;
using POS.Application.Authentication.Common;
using POS.Presentation.Authentication;

namespace POS.WebApi.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginCommand>();
        config.NewConfig<RefreshRequest, RefreshCommand>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest.RefreshToken, src => src.User.RefreshToken.Value);
    }
}
