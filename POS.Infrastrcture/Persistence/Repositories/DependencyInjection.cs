using Microsoft.Extensions.DependencyInjection;
using POS.Application.Common.Interfaces.Persistence;

namespace POS.Infrastrcture.Persistence.Repositories;

public static class DependencyInjection
{

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}