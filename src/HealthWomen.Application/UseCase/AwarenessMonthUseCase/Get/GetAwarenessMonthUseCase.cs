using HealthWomen.Communication.ResponseDTO.AwarenessMonth.Get;
using HealthWomen.Domain.Repositories;
using Mapster;
using MapsterMapper;

namespace HealthWomen.Application.UseCase.AwarenessMonthUseCase.Get;
/// <summary>
/// Classe para regra de negócio
/// </summary>
public class GetAwarenessMonthUseCase : IGetAwarenessMonthUseCase
{
    private readonly IAwarenessMonthQuery _awarenessQuery;
    public GetAwarenessMonthUseCase(IAwarenessMonthQuery awarenessQuery)
    {
        _awarenessQuery = awarenessQuery;
    }
    /// <summary>
    /// Método para obter a lista completa do mês da concientização.
    /// </summary>
    /// <returns>Retorno em lista</returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResponseListAwarenessMonthDTO> GetAllExecute()
    {
        var getAllAwaraness = await _awarenessQuery.GetAwarenessMonths();
        if (getAllAwaraness.Count is 0)
            throw new Exception("Nenhum mês de conscientização encontrado no banco de dados.");

        var response = getAllAwaraness.Adapt<List<ResponseAwarenessMonthDTO>>();
        return new ResponseListAwarenessMonthDTO { AwarenessMonths = response };
    }
    /// <summary>
    /// Método para obter o mês da concientização, filtrando com o mês-ano
    /// </summary>
    /// <param name="month">Parâmetro via request</param>
    /// <returns>Retorno de apenas 1 (Mês)</returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResponseAwarenessMonthDTO> GetByNameExecute(string month)
    {
        var getByMonth = await _awarenessQuery.GetAwarenessByMonth(month) ?? throw new Exception("Mês inválido. Os meses válidos são: Marco, Agosto e Outubro.");
        var response = getByMonth.Adapt<ResponseAwarenessMonthDTO>();
        return response;
    }
}
