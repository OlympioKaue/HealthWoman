using System.Text.Json.Serialization;

namespace HealthWoman.Communication.ResponseDTO.Woman.Get;

public class ResponseGetAllWomanDTO
{
    public string? WomanName { get; set; }
    public int Age { get; set; }
    public int NumberOfChildren { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContainsExistingDisease { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Diseases { get; set; } = [];
}
