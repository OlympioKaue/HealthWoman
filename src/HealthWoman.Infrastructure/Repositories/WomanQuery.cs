using HealthWoman.Domain.Entities;
using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthWoman.Infrastructure.Repositories;

internal class WomanQuery : IWomanQuery
{
    private readonly HealthWomanDbContext _context;
    public WomanQuery(HealthWomanDbContext context)
    {
        _context = context;
    }

    public async Task<List<TResult>> GetAllWoman<TResult>(Expression<Func<Woman, TResult>> selector)
    {
        return await _context.woman.AsNoTracking().Select(selector).ToListAsync();
    }

    public async Task<Woman?> GetById(int id)
    {
        return await _context.woman.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> WomanExistsByThisName(string womanName)
    {
        return await _context.woman.AnyAsync(query => query.WomanName!.ToLower() == womanName.ToLower());
    }
}
