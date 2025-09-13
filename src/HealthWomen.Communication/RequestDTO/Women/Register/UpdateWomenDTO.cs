namespace HealthWomen.Communication.RequestDTO.Woman.Register;

public class UpdateWomanDTO
{
    public string? WomanName { get; set; }
    public int? Age { get; set; }
    public int? NumberOfChildren { get; set; }
    public string? ContainsExistingDiseases { get; set; }
    public List<string?> DiseaseName { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
