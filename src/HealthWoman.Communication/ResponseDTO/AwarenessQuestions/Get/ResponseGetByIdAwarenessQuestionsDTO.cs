using System.Text.Json.Serialization;

namespace HealthWoman.Communication.ResponseDTO.AwarenessQuestions.Get;

public class ResponseGetByIdAwarenessQuestionsDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Answer { get; set; }
}
