using System.Text.Json.Serialization;

namespace HealthWomen.Communication.ResponseDTO.AwarenessQuestions.Get;

public class ResponseGetByIdAwarenessQuestionsDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Answer { get; set; }
}
