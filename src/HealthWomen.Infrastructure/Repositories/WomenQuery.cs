using System.Linq.Expressions;
using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using HealthWomen.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
namespace HealthWomen.Infrastructure.Repositories;
internal class WomenQuery : IWomenQuery
{
    private readonly HealthWomenDbContext _context;

    public WomenQuery(HealthWomenDbContext context)
    {
        _context = context;
    }

    public async Task<List<TResult>> GetGenericData<TResult>(Expression<Func<Woman, TResult>> selector)
    {
        return await _context.woman.AsNoTracking().Select(selector).ToListAsync();
    }

    public async Task<bool> GetByName(string womanName)
    {
        return await _context.woman.AnyAsync(query => query.WomanName! == womanName);
    }

    public async Task<Woman?> GetWomanById(int id)
    {
        return await _context.woman
            .Include(x => x.Diseases)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}