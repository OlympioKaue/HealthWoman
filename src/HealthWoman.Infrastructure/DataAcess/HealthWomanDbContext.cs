using HealthWoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthWoman.Infrastructure.DataAcess;

public class HealthWomanDbContext : DbContext
{
    public HealthWomanDbContext(DbContextOptions option) : base(option) {}
    public DbSet<Woman> woman { get; set; }
    public DbSet<AwarenessMonth> awarenessMonths { get; set; }
    public DbSet<HealthQuestions> healthQuestions { get; set; }
    public DbSet<Diseases> diseases { get; set; }
    //public DbSet<WomanDiseases> womanDiseases { get; set; }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Woman>()
            .HasMany(x => x.Diseases)
            .WithOne(x => x.Woman)
            .HasForeignKey(x => x.WomanId);
        
        


    }

}
