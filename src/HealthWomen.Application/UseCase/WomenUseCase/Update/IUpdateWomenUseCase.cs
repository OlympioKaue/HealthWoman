using HealthWomen.Communication.ResponseDTO.Woman.Register;
using HealthWomen.Application.Reflection;
using HealthWomen.Communication.RequestDTO.Woman.Register;

namespace HealthWomen.Application.UseCase.WomanUseCase.Update;

public interface IUpdateWomanUseCase : IGenericApplication
{
    Task UpdateExecute(UpdateWomanDTO update, int id);
}
