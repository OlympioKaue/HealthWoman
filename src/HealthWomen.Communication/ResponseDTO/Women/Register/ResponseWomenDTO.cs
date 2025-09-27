namespace HealthWomen.Communication.ResponseDTO.Women.Register;
/// <summary>
/// return response DTO, 
/// </summary>
public record class ResponseWomanDTO
{
    public int Id { get; init; }
    public string? ReturnMessage { get; init; }
    
    public static ResponseWomanDTO Response(int id, string? returnMessage)
      => new ResponseWomanDTO{Id = id, ReturnMessage = returnMessage};
    
}
