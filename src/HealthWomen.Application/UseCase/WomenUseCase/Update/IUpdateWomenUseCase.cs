using HealthWomen.Communication.ResponseDTO.Woman.Register;
using HealthWomen.Application.Reflection;
using HealthWomen.Communication.RequestDTO.Woman.Register;

namespace HealthWomen.Application.UseCase.WomanUseCase.Update;
/// <summary>
/// Interface para o uso na regra de negócio
/// </summary>
public interface IUpdateWomanUseCase : IGenericApplication
{
    /// <summary>
    /// Método de executar na regra de negócio
    /// </summary>
    /// <param name="update">Parâmetro via request, dados a serem atualizados</param>
    /// <param name="id">Parâmetro via reques, ID da mulher</param>
    /// <returns>Sem retorno</returns>
    Task UpdateExecute(UpdateWomanDTO update, int id);
}
