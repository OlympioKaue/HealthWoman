using HealthWoman.Application.Reflection;
using HealthWoman.Communication.ResponseDTO.Woman.Get;

namespace HealthWoman.Application.UseCase.WomanUseCase.Get;

public interface IGetWomanUseCase : IGenericApplication
{
    Task<ResponseGetListWomanDTO> GetAllExecute();
    Task<ResponseGetAllWomanDTO> GetByIdExecute(int id);
}
