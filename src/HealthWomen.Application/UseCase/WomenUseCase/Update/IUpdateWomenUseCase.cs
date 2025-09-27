using HealthWomen.Application.Reflection;
using HealthWomen.Communication.RequestDTO.Women.Register;

namespace HealthWomen.Application.UseCase.WomenUseCase.Update;

public interface IUpdateWomanUseCase : IGenericApplication
{ 
    Task UpdateExecute(UpdateWomanDTO updateRequest, int id);
}