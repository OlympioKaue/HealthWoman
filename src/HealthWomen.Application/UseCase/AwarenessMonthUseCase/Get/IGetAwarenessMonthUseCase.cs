using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.AwarenessMonth.Get;

namespace HealthWomen.Application.UseCase.AwarenessMonthUseCase.Get;
/// <summary>
/// Interface para a regra de negócio
/// </summary>
public interface IGetAwarenessMonthUseCase : IGenericApplication
{
    /// <summary>
    /// Método para obter a lista completa do mês da concientização.
    /// </summary>
    /// <returns>Retorno em lista</returns>
    Task<ResponseListAwarenessMonthDTO> GetAllExecute();
    /// <summary>
    /// Método para obter o mês da concientização, filtrando com o mês-ano
    /// </summary>
    /// <param name="month">Parâmetro via request</param>
    /// <returns>Retorno de apenas 1 (Mês)</returns>
    Task<ResponseAwarenessMonthDTO> GetByNameExecute(string month);
}
