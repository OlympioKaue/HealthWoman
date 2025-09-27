namespace HealthWomen.Communication.ResponseDTO.Women.Get;

public class ResponseGetAllWomanDTO
{
    public string? WomanName { get; set; }
    public int Age { get; set; }
    public int NumberOfChildren { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContainsExistingDisease { get; set; }
}
