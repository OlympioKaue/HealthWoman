namespace HealthWomen.Domain.Entities;

public class Diseases
{
    public int Id { get; set; }
    public string? DiseaseName { get; set; }
    public int WomanId { get; set; }
    public Women Woman { get; set; } = null!;

}
