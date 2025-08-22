using HealthWoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthWoman.Infrastructure.DataAcess;

public class HealthWomanDbContext : DbContext
{
    public HealthWomanDbContext(DbContextOptions option) : base(option) {}
    public DbSet<Woman> woman { get; set; }
    public DbSet<AwarenessMonth> awarenessMonths { get; set; }
    public DbSet<HealthQuestions> healthQuestions { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       

    }

}
