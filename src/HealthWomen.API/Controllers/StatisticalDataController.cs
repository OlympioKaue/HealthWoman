using HealthWomen.Application.UseCase.StatisticalData.Get;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthWomen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalDataController : ControllerBase
    {
        /// <summary>
        /// Obter dados estatíticos
        /// </summary>
        /// <param name="useCase">Dados sobre a regra de negócio</param>
        /// <returns>Retorno dos dados (Mulheres Cadastrada, Papanicolau, Doenças encontradas, Numero de Doenças mais comum) </returns>
        [HttpGet]
        public async Task<IActionResult> GetStatic([FromServices] IGetStatisticalDataUseCase useCase)
        {
            var result = await useCase.GetStaticalExecute();
            return Ok(result);
        }

    }
}
