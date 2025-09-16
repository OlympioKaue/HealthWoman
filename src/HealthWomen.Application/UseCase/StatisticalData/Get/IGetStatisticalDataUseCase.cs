using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.StatisticalData.Get;

namespace HealthWomen.Application.UseCase.StatisticalData.Get;
/// <summary>
/// Interface da regra de negócio
/// </summary>
public interface IGetStatisticalDataUseCase : IGenericApplication
{
    /// <summary>
    /// Executar método da regra de negócio
    /// </summary>
    /// <returns>Retorno dos dados estatíticos</returns>
    Task<ResponseStatisticalDataWoman> GetStaticalExecute();
}
