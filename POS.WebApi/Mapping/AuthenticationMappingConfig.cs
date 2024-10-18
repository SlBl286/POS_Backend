using Mapster;
using POS.Application.Authentication.Commands.Register;
using POS.Application.Authentication.Common;
using POS.Application.Authentication.Queries.Login;
using POS.Presentation.Authentication;

namespace POS.WebApi.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User)
                .Map(dest => dest.Id, src => src.User.Id.Value.ToString());
    }
}
