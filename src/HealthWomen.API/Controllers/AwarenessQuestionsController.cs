using HealthWomen.Application.UseCase.AwarenessQuestionsUseCase.Get;
using Microsoft.AspNetCore.Mvc;

namespace HealthWomen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwarenessQuestionsController : ControllerBase
{
    /// <summary>
    /// Obter perguntas pré-definidas
    /// </summary>
    /// <param name="UseCase">Dados da regra de negócio</param>
    /// <returns>Retorno das perguntas</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IGetAwarenessQuestionsUseCase UseCase)
    {
        var result = await UseCase.GetAllExecute();    
        return Ok(result);
    }
    /// <summary>
    /// Obter respostas pré-definidas, filtrando pelo ID
    /// </summary>
    /// <param name="useCase">Dados da regra de negócio</param>
    /// <param name="id">Parâmetro via request</param>
    /// <returns>Retorno das respostas</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromServices] IGetAwarenessQuestionsUseCase useCase, [FromRoute] int id)
    {
       var result = await useCase.GetByIdExecute(id);
       return Ok(result);
    }

   
}
