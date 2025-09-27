using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.Women.Get;

namespace HealthWomen.Application.UseCase.WomenUseCase.Get;
public interface IGetWomanUseCase : IGenericApplication
{
    Task<ResponseListWomen> GetAllExecute();
}
