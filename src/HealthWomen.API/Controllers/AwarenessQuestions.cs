using HealthWomen.Domain.Repositories;
using HealthWomen.Application.UseCase.AwarenessQuestionsUseCase.Get;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthWomen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwarenessQuestions : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAwarenessQuestions([FromServices] IGetAwarenessQuestionsUseCase UseCase)
    {
        var result = await UseCase.GetAllExecute();    
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByAwarenessQuestions([FromServices] IGetAwarenessQuestionsUseCase useCase, [FromRoute]int id)
    {
       var result = await useCase.GetByIdExecute(id);
       return Ok(result);
    }

   
}
