using HealthWoman.Application.UseCase.AwarenessQuestionsUseCase.Get;
using Microsoft.AspNetCore.Mvc;

namespace HealthWoman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwarenessQuestions : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAwarenessQuestions([FromServices] IGetAwarenessQuestionsUseCase UseCase)
    {
        var result = await UseCase.GetExecute();    
        return Ok(result);
    }
}
