using System.Linq.Expressions;
using HealthWomen.Domain.Entities;

namespace HealthWomen.Domain.Repositories;

public interface IWomenQuery
{
    Task<bool> GetByName(string womanName);
    Task<List<TResult>> GetGenericData<TResult>(Expression<Func<Woman, TResult>> selector);
    Task<Woman?> GetWomanById(int id);
}
