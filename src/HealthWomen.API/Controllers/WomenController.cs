using HealthWomen.Application.UseCase.WomanUseCase.Get;
using HealthWomen.Application.UseCase.WomanUseCase.Register;
using HealthWomen.Application.UseCase.WomanUseCase.Update;
using HealthWomen.Communication.RequestDTO.Woman.Register;
using HealthWomen.Communication.ResponseDTO.Woman.Register;
using Microsoft.AspNetCore.Mvc;

namespace HealthWomen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WomenController : ControllerBase
{
    /// <summary>
    /// Registrar um usuário (Mulher) no banco de dados
    /// </summary>
    /// <param name="register">Dados da mulher a ser cadastrado</param>
    /// <param name="useCase">Dados da regra de negócio</param>
    /// <returns>Retorno da entidade cadastradas</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ResponseWomanDTO), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterWomanDTO register, [FromServices] IRegisterWomanUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(register);
        return Created("", result);
    }

    /// <summary>
    /// Obter dados simplificados do registro.
    /// </summary>
    /// <param name="useCase">Dados da regra de negócio</param>
    /// <returns>Retorno dos registros cadastrados</returns>
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IGetWomanUseCase useCase)
    {
        var result = await useCase.GetAllExecute();
        return Ok(result);
    }

    /// <summary>
    /// Obter dados completos do registro, filtrando apenas pelo ID
    /// </summary>
    /// <param name="useCase">Dados da regra de negócio</param>
    /// <param name="id">Parâmetro enviado pela request, ID da mulher</param>
    /// <returns>Retorne os dados completos</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromServices] IGetWomanUseCase useCase, int id)
    {
        var result = await useCase.GetByIdExecute(id);
        return Ok(result);
    }
    /// <summary>
    /// Atualização dos dados cadastrados, Filtre pelo ID
    /// </summary>
    /// <param name="useCase">Dados da regra de negócio</param>
    /// <param name="update">Parâmetro via request (Dados a serem atualizados)</param>
    /// <param name="id">Parâmetro enviado pela request, ID da mulher</param>
    /// <returns>Não retorne nada, apenas atualize os dados cadastrados</returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromServices] IUpdateWomanUseCase useCase, [FromBody] UpdateWomanDTO update, [FromRoute] int id)
    {
        await useCase.UpdateExecute(update, id);
        return NoContent();
    }

}
