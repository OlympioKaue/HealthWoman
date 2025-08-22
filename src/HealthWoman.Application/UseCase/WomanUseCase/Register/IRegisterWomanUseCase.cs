using HealthWoman.Application.Reflection;
using HealthWoman.Communication.RequestDTO.Woman.Register;
using HealthWoman.Communication.ResponseDTO.Woman.Register;

namespace HealthWoman.Application.UseCase.WomanUseCase.Register;
public interface IRegisterWomanUseCase : IGenericApplication
{
    Task<ResponseWomanDTO> RegisterExecute(RegisterWomanDTO registerWoman);
}
