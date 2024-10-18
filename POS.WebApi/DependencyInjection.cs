
using CA.WebApi.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using POS.WebApi.Common.Errors;

namespace POS.WebApi;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddMapping();
        return services;
    }
}