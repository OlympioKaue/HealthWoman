using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.AwarenessQuestions.Get;

namespace HealthWomen.Application.UseCase.AwarenessQuestionsUseCase.Get;
/// <summary>
/// Interface para a regra de negócio
/// </summary>
public interface IGetAwarenessQuestionsUseCase : IGenericApplication
{
    /// <summary>
    /// Executar o método da regra de negócio
    /// </summary>
    /// <returns>Retorno das perguntas pré definidas</returns>
    Task<ResponseListAwarenessQuestionsDTO> GetAllExecute();
    /// <summary>
    /// Executar o método da regra de negócio
    /// </summary>
    /// <param name="id">Parâmetro via request</param>
    /// <returns>retorno da respostas pré definidas</returns>
    Task<ResponseGetByIdAwarenessQuestionsDTO> GetByIdExecute(int id); 
   
}
