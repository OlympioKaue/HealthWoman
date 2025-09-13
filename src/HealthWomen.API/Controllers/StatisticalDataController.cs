using HealthWomen.Application.UseCase.StatisticalData.Get;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthWomen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalDataController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStaticWomanData([FromServices] IGetStatisticalDataUseCase useCase)
        {
            var result = await useCase.GetExecute();
            return Ok(result);
        }

    }
}
