using HealthWoman.Application.Reflection;
using HealthWoman.Communication.ResponseDTO.AwarenessMonth.Get;

namespace HealthWoman.Application.UseCase.AwarenessMonthUseCase.Get;

public interface IGetAwarenessMonthUseCase : IGenericApplication
{
    Task<ResponseListAwarenessMonthDTO> GetExecute();
}
