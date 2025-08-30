using System.Text.Json.Serialization;

namespace HealthWoman.Communication.ResponseDTO.AwarenessQuestions.Get;

public class ResponseAwarenessQuestionsDTO
{
    public int Id { get; set; }
    public string? Question { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Answer { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int MinAge { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int MaxAge { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Category { get; set; }
}
