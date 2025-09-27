using HealthWomen.Domain.Entities;
using System.Linq.Expressions;

namespace HealthWomen.Domain.Repositories;

public interface IStatisticalDataQuery
{
    Task<List<Woman>> GetStatisticalDataAsync();

}
