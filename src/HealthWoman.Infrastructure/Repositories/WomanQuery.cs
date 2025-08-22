using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace HealthWoman.Infrastructure.Repositories;

internal class WomanQuery : IWomanQuery
{
    private readonly HealthWomanDbContext _context;
    public WomanQuery(HealthWomanDbContext context)
    {
        _context = context;
    }
    public async Task<bool> WomanExistsByThisName(string womanName)
    {
        return await _context.woman.AnyAsync(query => query.WomanName == womanName);
    }
}
