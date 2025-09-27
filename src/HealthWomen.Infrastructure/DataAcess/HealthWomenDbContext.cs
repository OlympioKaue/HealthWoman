using HealthWomen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthWomen.Infrastructure.DataAcess;

public class HealthWomenDbContext : DbContext
{
    public HealthWomenDbContext(DbContextOptions option) : base(option) {}
    public DbSet<Woman> woman { get; set; }
    public DbSet<AwarenessMonth> awarenessMonths { get; set; }
    public DbSet<AwarenessQuestions> awarenessQuestions { get; set; }
    public DbSet<Diseases> diseases { get; set; }
 
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Woman>()
            .HasMany(x => x.Diseases)
            .WithOne(x => x.Woman)
            .HasForeignKey(x => x.WomanId)
            .OnDelete(DeleteBehavior.Cascade);

      


    }

}
