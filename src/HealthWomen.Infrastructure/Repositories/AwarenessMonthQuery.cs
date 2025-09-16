using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using HealthWomen.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace HealthWomen.Infrastructure.Repositories;

internal class AwarenessMonthQuery : IAwarenessMonthQuery
{
    private readonly HealthWomenDbContext _context;
    public AwarenessMonthQuery(HealthWomenDbContext context)
    {
        _context = context;
    }

    public async Task<List<AwarenessMonth>> GetAwarenessMonths()
    {
        return await _context.awarenessMonths.AsNoTracking().OrderBy(am => am.Id).ToListAsync();
    }

    public async Task<AwarenessMonth?> GetAwarenessByMonth(string month)
    {
        if (string.IsNullOrWhiteSpace(month))
            return null;

        var query = month.ToLower() switch
        {
            "marco" => "março lilás",
            "agosto" => "agosto lilás",
            "outubro" => "outubro rosa",
            _ => month
        };

        return await _context.awarenessMonths.AsNoTracking().FirstOrDefaultAsync(x => x.MonthName!.ToLower() == query.ToLower());

    }
}
