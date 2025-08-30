using HealthWoman.Application.UseCase.WomanUseCase.Get;
using HealthWoman.Application.UseCase.WomanUseCase.Register;
using HealthWoman.Communication.RequestDTO.Woman.Register;
using HealthWoman.Communication.ResponseDTO.Woman.Register;
using Microsoft.AspNetCore.Mvc;

namespace HealthWoman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WomanController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseWomanDTO), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterWomanDTO registerWoman, [FromServices] IRegisterWomanUseCase useCase)
    {
        var result = await useCase.RegisterExecute(registerWoman);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetWoman([FromServices] IGetWomanUseCase useCase)
    {
        var result = await useCase.GetAllExecute();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdWoman([FromServices] IGetWomanUseCase useCase, int id)
    {
        var result = await useCase.GetByIdExecute(id);
        return Ok(result);
    }
}
