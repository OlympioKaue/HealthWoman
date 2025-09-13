using HealthWomen.Application.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HealthWomen.Application.Extension;

public static class ApplicationExtensionAndProgram
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddUseCase();
    }

    private static void AddUseCase(this IServiceCollection services)
    {
        var assembly = typeof(IGenericApplication).Assembly;

        assembly
        .GetTypes()
        .Where(type => type.IsClass && !type.IsAbstract)
        .SelectMany(type => type.GetInterfaces()
        .Where(interfaces => interfaces != typeof(IGenericApplication)
         && typeof(IGenericApplication).IsAssignableFrom(interfaces)),
        (type, face) => new { type, face })
        .ToList()
        .ForEach(add => services.AddScoped(add.face, add.type));


    }
}
