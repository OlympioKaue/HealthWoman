using HealthWomen.Application.Reflection;
using HealthWomen.Communication.RequestDTO.Women.Register;
using HealthWomen.Communication.ResponseDTO.Women.Register;
namespace HealthWomen.Application.UseCase.WomenUseCase.Register;
public interface IRegisterWomanUseCase : IGenericApplication
{
    Task<ResponseWomanDTO> ExecuteAsync(RegisterWomanDto requestRegister);
}