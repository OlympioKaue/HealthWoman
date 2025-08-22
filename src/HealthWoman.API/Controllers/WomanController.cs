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
    [ProducesResponseType(typeof(ResponseWomanDTO),StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterWomanDTO registerWoman, [FromServices] IRegisterWomanUseCase useCase)
    {
        var result = await useCase.RegisterExecute(registerWoman);
        return Created("", result);
    }
}
