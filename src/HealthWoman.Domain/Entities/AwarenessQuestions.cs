namespace HealthWoman.Domain.Entities;

public class AwarenessQuestions
{
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public int? MinAge { get; set; } 
    public int? MaxAge { get; set; }
    public string? Category { get; set; }
}
