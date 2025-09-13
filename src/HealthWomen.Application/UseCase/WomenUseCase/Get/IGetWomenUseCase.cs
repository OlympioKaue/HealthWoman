using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.Woman.Get;

namespace HealthWomen.Application.UseCase.WomanUseCase.Get;

/// <summary>
/// Interface de retorno na regra de negócio
/// </summary>
public interface IGetWomanUseCase : IGenericApplication
{
    /// <summary>
    /// Executar o método na regra de negócio
    /// </summary>
    /// <returns>Retorno dos dados cadastrados</returns>
    Task<ResponseGetListWomanDTO> GetAllExecute();
    /// <summary>
    /// Executar o método na regra de negócio
    /// </summary>
    /// <param name="id">Parâmetro enviado via Rota</param>
    /// <returns>Retorno dos dados cadastrados, filtrandos apenas pelo ID</returns>
    Task<ResponseGetAllWomanDTO> GetByIdExecute(int id);

}
