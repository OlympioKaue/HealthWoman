using HealthWomen.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HealthWomen.Domain.Repositories;
using HealthWomen.Domain.Entities;


namespace HealthWomen.Infrastructure.Repositories;

internal class WomenQuery : IWomenQuery
{
    private readonly HealthWomenDbContext _context;
    public WomenQuery(HealthWomenDbContext context)
    {
        _context = context;
    }

    public async Task<List<TResult>> GetSelectedItem<TResult>(Expression<Func<Women, TResult>> selector)
    {
        return await _context.woman.AsNoTracking().Select(selector).ToListAsync();

    }

    /// <summary>
    /// Busca o nome no banco de dados.
    /// </summary>
    /// <param name="womanName">Dados enviados pela request.</param>
    /// <returns>Retorne se existe o parâmetro womanName no banco de dados, (Retorno Bool).</returns>
    public async Task<bool> GetByName(string womanName)
    {
        return await _context.woman.AnyAsync(query => query.WomanName! == womanName);
    }

    public async Task<Women?> GetById(int id)
    {
        return await _context.woman.Include(x => x.Diseases).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }


}
