using HealthWomen.Domain.Entities;
using System.Linq.Expressions;

namespace HealthWomen.Domain.Repositories;

public interface IWomenQuery
{
    /// <summary>
    /// Busca o nome no banco de dados.
    /// </summary>
    /// <param name="womanName">Dados enviados pela request.</param>
    /// <returns>Retorne se existe o parâmetro womanName no banco de dados, (Retorno Bool).</returns>
    Task<bool> GetByName(string womanName);
    Task<List<TResult>> GetSelectedItem<TResult>(Expression<Func<Women, TResult>> selector);
    Task<Women?> GetById(int id);
}
