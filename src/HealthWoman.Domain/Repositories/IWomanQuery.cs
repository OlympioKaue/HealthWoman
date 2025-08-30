using HealthWoman.Domain.Entities;
using System.Linq.Expressions;

namespace HealthWoman.Domain.Repositories;

public interface IWomanQuery
{
    Task<bool> WomanExistsByThisName(string womanName);
    Task<List<TResult>> GetAllWoman<TResult>(Expression<Func<Woman, TResult>> selector);
    Task<Woman?> GetById(int id);
}
