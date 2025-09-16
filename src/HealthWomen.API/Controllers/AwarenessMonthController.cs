using HealthWomen.Application.UseCase.AwarenessMonthUseCase.Get;
using Microsoft.AspNetCore.Mvc;

namespace HealthWomen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwarenessMonthController : ControllerBase
{
    /// <summary>
    /// Obter o mês de concientização.
    /// </summary>
    /// <param name="useCase">Dados da regra de negócio</param>
    /// <returns>Retorno do mês da concientização</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IGetAwarenessMonthUseCase useCase)
    {
        var result = await useCase.GetAllExecute();
        return Ok(result);
    }
    /// <summary>
    /// Obter o mês de concientização, filtrando pelo nome do mês
    /// </summary>
    /// <param name="useCase">Dados da regra de negócio</param>
    /// <param name="month">Dados via request</param>
    /// <returns></returns>
    [HttpGet("month")]
    public async Task<IActionResult> GetByNameMonth([FromServices] IGetAwarenessMonthUseCase useCase, [FromHeader] string month)
    {
        var result = await useCase.GetByNameExecute(month);
        return Ok(result);
    }


    
}