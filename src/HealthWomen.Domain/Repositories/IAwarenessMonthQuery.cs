using HealthWomen.Domain.Entities;

namespace HealthWomen.Domain.Repositories;

public interface IAwarenessMonthQuery
{
    Task<List<AwarenessMonth>> GetAwarenessMonth();
    Task<AwarenessMonth?> GetByIdAwarenessMonth(string month);
}
