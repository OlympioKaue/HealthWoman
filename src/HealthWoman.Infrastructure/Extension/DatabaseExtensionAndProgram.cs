using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;
using HealthWoman.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthWoman.Infrastructure.AssemblyExtension;

public static class DatabaseExtensionAndProgram
{
    public static void AddExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWomanCommand, WomanCommand>();
        services.AddScoped<IWomanQuery, WomanQuery>();
        services.AddScoped<IAwarenessMonthQuery, AwarenessMonthQuery>();
        services.AddScoped<IAwarenessQuestionsQuery, AwarenessQuestionsQuery>();
        services.AddScoped<ISaveChangesCommand, SaveChangesCommand>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var conctionString = configuration.GetConnectionString("DefaultConnection");
        var version = new MySqlServerVersion(new Version(8, 0, 41));

        services.AddDbContext<HealthWomanDbContext>(options =>
         options.UseMySql(conctionString, version, b => b.MigrationsAssembly("HealthWoman.Infrastructure")));

    }
}