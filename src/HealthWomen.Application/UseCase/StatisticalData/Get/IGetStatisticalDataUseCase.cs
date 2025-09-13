using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.StatisticalData.Get;

namespace HealthWomen.Application.UseCase.StatisticalData.Get;

public interface IGetStatisticalDataUseCase : IGenericApplication
{
    Task<ResponseStatisticalDataWoman> GetExecute();
}
