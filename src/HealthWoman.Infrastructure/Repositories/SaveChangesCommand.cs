using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;

namespace HealthWoman.Infrastructure.Repositories;

internal class SaveChangesCommand : ISaveChangesCommand
{
    private readonly HealthWomanDbContext _context;
    public SaveChangesCommand(HealthWomanDbContext context)
    {
        _context = context;
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
