using HealthWomen.Communication.ResponseDTO.AwarenessQuestions.Get;
using HealthWomen.Domain.Repositories;

namespace HealthWomen.Application.UseCase.AwarenessQuestionsUseCase.Get;
/// <summary>
/// classe da regra de negócio
/// </summary>
public class GetAwarenessQuestionsUseCase : IGetAwarenessQuestionsUseCase
{
    private readonly IAwarenessQuestionsQuery _awarenessQuestionsQuery;
    public GetAwarenessQuestionsUseCase(IAwarenessQuestionsQuery awarenessQuestionsQuery)
    {
        _awarenessQuestionsQuery = awarenessQuestionsQuery;
    }
    /// <summary>
    /// Executar o método da regra de negócio
    /// </summary>
    /// <returns>Retorno das perguntas pré definidas</returns>
    public async Task<ResponseListAwarenessQuestionsDTO> GetAllExecute()
    {
        var getResponse = await _awarenessQuestionsQuery
        .GetAllAsync(x => new ResponseAwarenessQuestionsDTO
        {
            Id = x.Id,
            Question = x.Question,
        });

        return new ResponseListAwarenessQuestionsDTO { AwarenessQuestions = getResponse };
    }
    /// <summary>
    /// Executar o método da regra de negócio
    /// </summary>
    /// <param name="id">Parâmetro via request</param>
    /// <returns>retorno da respostas pré definidas</returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResponseGetByIdAwarenessQuestionsDTO> GetByIdExecute(int id)
    {
        var result = await _awarenessQuestionsQuery.GetByIdAsync(id, x => new ResponseGetByIdAwarenessQuestionsDTO
        {
            Answer = x.Answer
        });

        return result is null ? throw new Exception("Não encontrado respostas vinculadas a esse ID.") : result;
    }


}
