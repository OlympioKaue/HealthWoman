namespace HealthWomen.Communication.RequestDTO.Women.Register;

public class RegisterWomanDto
{
    public string? WomanName { get; set; }
    public int Age { get; set; }
    public int NumberOfChildren { get; set; }
    public string? ContainsExistingDisease { get; set; } 
    public List<string?> DiseaseName { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}