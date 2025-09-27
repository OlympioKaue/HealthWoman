using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using HealthWomen.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HealthWomen.Infrastructure.Repositories;

internal class WomenCommand : IWomenCommand
{
    private readonly HealthWomenDbContext _context;
    public WomenCommand(HealthWomenDbContext context)
    {
        _context = context;
    }

    public async Task AddWoman(Woman addWoman)
    {
        await _context.woman.AddAsync(addWoman);
    }

    public void UpdateWoman(Woman updateWoman)
    {
        _context.woman.Update(updateWoman);
    }
}
