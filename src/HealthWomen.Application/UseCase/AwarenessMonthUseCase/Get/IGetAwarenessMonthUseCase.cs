using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.AwarenessMonth.Get;

namespace HealthWomen.Application.UseCase.AwarenessMonthUseCase.Get;

public interface IGetAwarenessMonthUseCase : IGenericApplication
{
    Task<ResponseListAwarenessMonthDTO> GetAllExecute();
    Task<ResponseAwarenessMonthDTO> GetByMonthNameExecute(string month);
}
