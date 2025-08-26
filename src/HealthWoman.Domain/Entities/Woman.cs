using System.ComponentModel.DataAnnotations;

namespace HealthWoman.Domain.Entities;

public class Woman
{
    public int Id { get; set; }
    public string? WomanName { get; set; }
    public int Age { get; set; }
    public int NumberOfChildren { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public bool ContainsExistingDisease { get; set; }
    public ICollection<Diseases> Diseases { get; set; } = [];




}
