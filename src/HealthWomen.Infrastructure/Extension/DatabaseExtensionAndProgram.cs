using HealthWomen.Domain.Repositories;
using HealthWomen.Infrastructure.DataAcess;
using HealthWomen.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;
using OpenAI.Chat;

namespace HealthWomen.Infrastructure.Extension;

public static class DatabaseExtensionAndProgram
{
    public static void AddExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDbContext(configuration);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWomenCommand, WomenCommand>();
        services.AddScoped<IWomenQuery, WomenQuery>();
        services.AddScoped<IAwarenessMonthQuery, AwarenessMonthQuery>();
        services.AddScoped<IAwarenessQuestionsQuery, AwarenessQuestionsQuery>();
        services.AddScoped<ISaveChangesCommand, SaveChangesCommand>();
        services.AddScoped<IStatisticalDataQuery, StatisticalDataQuery>();

     
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var conctionString = configuration.GetConnectionString("DefaultConnection");
        var version = new MySqlServerVersion(new Version(8, 0, 41));

        services.AddDbContext<HealthWomenDbContext>(options =>
         options.UseMySql(conctionString, version, b => b.MigrationsAssembly("HealthWomen.Infrastructure")));

    }
}