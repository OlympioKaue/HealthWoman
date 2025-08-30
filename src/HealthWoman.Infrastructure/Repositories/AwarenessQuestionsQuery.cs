using HealthWoman.Domain.Entities;
using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthWoman.Infrastructure.Repositories;

internal class AwarenessQuestionsQuery : IAwarenessQuestionsQuery
{
    private readonly HealthWomanDbContext _context;
    public AwarenessQuestionsQuery(HealthWomanDbContext context)
    {
        _context = context;
    }

    public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<AwarenessQuestions, TResult>> selector)
    {
        return await _context.awarenessQuestions.AsNoTracking().Select(selector).ToListAsync();
    }

    public async Task<TResult?> GetByIdAsync<TResult>(int id, Expression<Func<AwarenessQuestions, TResult>> selector)
    {
        return await _context.awarenessQuestions.AsNoTracking().Where(x => x.Id == id).Select(selector).FirstOrDefaultAsync();
    }
}
