using HealthWomen.Domain.Entities;
using System.Linq.Expressions;

namespace HealthWomen.Domain.Repositories;

public interface IAwarenessQuestionsQuery
{
    /// <summary>
    /// Retorne o id e perguntas pré definidas, Encurta o retorno em apenas 2 dados
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="selector"></param>
    /// <returns></returns>
    Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<AwarenessQuestions, TResult>> selector);
    /// <summary>
    /// Retorne as respostas pré definidas, Filtre com id da pergunta
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="id"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    Task<TResult?> GetByIdAsync<TResult>(int id, Expression<Func<AwarenessQuestions, TResult>> selector);
   
}
