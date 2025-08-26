using HealthWoman.Domain.Entities;
using HealthWoman.Domain.Repositories;
using HealthWoman.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HealthWoman.Infrastructure.Repositories;

internal class WomanCommand : IWomanCommand
{
    private readonly HealthWomanDbContext _context;
    public WomanCommand(HealthWomanDbContext context)
    {
        _context = context;
    }

    public async Task AddWoman(Woman addWoman)
    {
        await _context.woman.AddAsync(addWoman);


    }
}
