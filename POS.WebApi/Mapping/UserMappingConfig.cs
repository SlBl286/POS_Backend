using Mapster;
using POS.Application.Users.Common;
using POS.Application.Users.Queries.GetUser;
using POS.Presentation.User;

namespace POS.WebApi.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid,GetUserQuery>()
            .Map(dest => dest.Id, src => src);
        config.NewConfig<UserResult, UserResponse>()
                .Map(dest => dest, src => src.User)
                .Map(dest => dest.Id, src => src.User.Id.Value);
    }
}
