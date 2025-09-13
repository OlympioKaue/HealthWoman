using HealthWomen.Domain.Entities;
using System.Linq.Expressions;

namespace HealthWomen.Domain.Repositories;

public interface IAwarenessQuestionsQuery
{
    Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<AwarenessQuestions, TResult>> selector);
    Task<TResult?> GetByIdAsync<TResult>(int id, Expression<Func<AwarenessQuestions, TResult>> selector);
   
}
