using HealthWoman.Application.UseCase.AwarenessMonthUseCase.Get;
using Microsoft.AspNetCore.Mvc;

namespace HealthWoman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwarenessMonthController : ControllerBase
{
    [HttpGet("teste")]
    public async Task<IActionResult> GetAwarenessDateMonths([FromServices] IGetAwarenessMonthUseCase useCase)
    {
        var result = await useCase.GetExecute();
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAllAwarenessMonths()
    {
        return Ok();
    }


    
}