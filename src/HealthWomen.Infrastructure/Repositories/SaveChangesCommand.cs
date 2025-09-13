using HealthWomen.Domain.Repositories;
using HealthWomen.Infrastructure.DataAcess;

namespace HealthWomen.Infrastructure.Repositories;

internal class SaveChangesCommand : ISaveChangesCommand
{
    private readonly HealthWomenDbContext _context;
    public SaveChangesCommand(HealthWomenDbContext context)
    {
        _context = context;
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
