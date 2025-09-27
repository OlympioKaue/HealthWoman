using HealthWomen.Application.UseCase.WomenUseCase.Get;
using HealthWomen.Application.UseCase.WomenUseCase.GetByID;
using HealthWomen.Application.UseCase.WomenUseCase.Register;
using HealthWomen.Application.UseCase.WomenUseCase.Update;
using HealthWomen.Communication.RequestDTO.Women.Register;
using HealthWomen.Communication.ResponseDTO.Women.Register;
using Microsoft.AspNetCore.Mvc;
namespace HealthWomen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WomenController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseWomanDTO), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register
        ([FromBody] RegisterWomanDto requestRegister, [FromServices] IRegisterWomanUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(requestRegister);
        return Created("", result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IGetWomanUseCase useCase)
    {
        var result = await useCase.GetAllExecute();
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromServices] IGetWomenByIdUseCase useCase, int id)
    {
        var result = await useCase.GetByIdExecute(id);
        return Ok(result);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateById([FromServices] IUpdateWomanUseCase useCase, 
        [FromBody] UpdateWomanDTO updateRequest, [FromRoute] int id)
    {
        await useCase.UpdateExecute(updateRequest, id);
        return NoContent();
    }

    //t
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById()
    {
        return NoContent(); 
    }
}