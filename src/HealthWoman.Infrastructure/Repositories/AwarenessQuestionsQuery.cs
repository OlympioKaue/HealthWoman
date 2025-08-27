using HealthWoman.Domain.Entities;
using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace HealthWoman.Infrastructure.Repositories;

internal class AwarenessQuestionsQuery : IAwarenessQuestionsQuery
{
    private readonly HealthWomanDbContext _context;
    public AwarenessQuestionsQuery(HealthWomanDbContext context)
    {
        _context = context;
    }

    public async Task<List<AwarenessQuestions>> GetAwarenessQuestions()
    {
        var tt =  await _context.awarenessQuestions.AsNoTracking().ToListAsync();

        tt.Select(x => x.Question).ToList();

        return tt;
    }
}
