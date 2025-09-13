using System.ComponentModel.DataAnnotations;

namespace HealthWomen.Domain.Entities;

public class Women
{
    public int Id { get; set; }
    public string? WomanName { get; set; }
    public int Age { get; set; }
    public int NumberOfChildren { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContainsExistingDisease { get; set; }
    public ICollection<Diseases> Diseases { get; set; } = [];




}
