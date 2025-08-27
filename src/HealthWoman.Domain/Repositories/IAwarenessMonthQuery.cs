using HealthWoman.Domain.Entities;

namespace HealthWoman.Domain.Repositories;

public interface IAwarenessMonthQuery
{
    Task<List<AwarenessMonth>> GetAwarenessMonth();
}
