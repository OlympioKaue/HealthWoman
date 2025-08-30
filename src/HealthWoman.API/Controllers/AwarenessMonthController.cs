using HealthWoman.Application.UseCase.AwarenessMonthUseCase.Get;
using Microsoft.AspNetCore.Mvc;

namespace HealthWoman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwarenessMonthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAwarenessMonth([FromServices] IGetAwarenessMonthUseCase useCase)
    {
        var result = await useCase.GetAllExecute();
        return Ok(result);
    }

    [HttpGet("month")]
    public async Task<IActionResult> GetByMonthAwarenessMonth([FromServices] IGetAwarenessMonthUseCase useCase, [FromHeader] string month)
    {
        var result = await useCase.GetByMonthNameExecute(month);
        return Ok(result);
    }


    
}