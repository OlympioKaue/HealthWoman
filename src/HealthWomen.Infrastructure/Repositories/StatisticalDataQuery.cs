using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using HealthWomen.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthWomen.Infrastructure.Repositories;

internal class StatisticalDataQuery : IStatisticalDataQuery
{
    private readonly HealthWomenDbContext _context;
    public StatisticalDataQuery(HealthWomenDbContext context)
    {
        _context = context;
    }

    public async Task<List<Women>> GetStatisticalDataAsync()
    {
        return await _context.woman.Include(x => x.Diseases).AsNoTracking().ToListAsync();
    }
}
