using HealthWomen.Domain.Entities;

namespace HealthWomen.Domain.Repositories;

public interface IAwarenessMonthQuery
{
    /// <summary>
    /// Obter os mêses de concientização em lista
    /// </summary>
    /// <returns>Retorne todos os mêses disponiveis</returns>
    Task<List<AwarenessMonth>> GetAwarenessMonths();
    /// <summary>
    /// Obter os mêses de concientização, filtrando pelo nome do mês
    /// </summary>
    /// <param name="month">Parâmetro via request</param>
    /// <returns>Retorne apenas o mês mencionado</returns>
    Task<AwarenessMonth?> GetAwarenessByMonth(string month);
}
