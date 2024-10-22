using Microsoft.Extensions.DependencyInjection;
using POS.Application.Common.Interfaces.Persistence;

namespace POS.Infrastrcture.Persistence.Repositories;

public static class DependencyInjection
{

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();

        return services;
    }
}