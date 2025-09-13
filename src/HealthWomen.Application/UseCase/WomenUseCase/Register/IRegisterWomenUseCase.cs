using HealthWomen.Application.Reflection;
using HealthWomen.Communication.RequestDTO.Woman.Register;
using HealthWomen.Communication.ResponseDTO.Woman.Register;

namespace HealthWomen.Application.UseCase.WomanUseCase.Register;
/// <summary>
/// Interface de retorno na regra de negócio
/// </summary>
public interface IRegisterWomanUseCase : IGenericApplication
{
    /// <summary>
    /// Executar o método na regra de negócio
    /// </summary>
    /// <param name="register">Dados enviados pela request</param>
    /// <returns>Retorno do registro</returns>
    Task<ResponseWomanDTO> ExecuteAsync(RegisterWomanDTO register);
    
}
