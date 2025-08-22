using HealthWoman.Domain.Entities;

namespace HealthWoman.Domain.Repositories;

public interface IWomanCommand
{
    Task AddWoman(Woman addWoman);
}
