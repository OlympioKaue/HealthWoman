using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.Women.Get;

namespace HealthWomen.Application.UseCase.WomenUseCase.GetByID;

public interface IGetWomenByIdUseCase : IGenericApplication
{
    Task<ResponseGetAllWomanDTO> GetByIdExecute(int id);
}