using HealthWoman.Domain.Entities;
using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace HealthWoman.Infrastructure.Repositories;

internal class AwarenessMonthQuery : IAwarenessMonthQuery
{
    private readonly HealthWomanDbContext _context;
    public AwarenessMonthQuery(HealthWomanDbContext context)
    {
        _context = context;
    }

    public async Task<List<AwarenessMonth>> GetAwarenessMonth()
    {
        return await _context.awarenessMonths.AsNoTracking().OrderBy(am => am.Id).ToListAsync();
    }
}
