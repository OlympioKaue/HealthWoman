using HealthWoman.Communication.ResponseDTO.AwarenessQuestions.Get;
using HealthWoman.Domain.Repositories;
using Mapster;

namespace HealthWoman.Application.UseCase.AwarenessQuestionsUseCase.Get;

public class GetAwarenessQuestionsUseCase : IGetAwarenessQuestionsUseCase
{
    private readonly IAwarenessQuestionsQuery _awarenessQuestionsQuery;
    public GetAwarenessQuestionsUseCase(IAwarenessQuestionsQuery awarenessQuestionsQuery)
    {
        _awarenessQuestionsQuery = awarenessQuestionsQuery;
    }

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

    public async Task<ResponseGetByIdAwarenessQuestionsDTO> GetByIdExecute(int id)
    {
       var result = await _awarenessQuestionsQuery.GetByIdAsync(
       id,
       x => new ResponseGetByIdAwarenessQuestionsDTO
       {
           Answer = x.Answer
       });

        if(result is null)
        {
            throw new Exception("Não encontrado respostas vinculadas a esse ID.");
        }
     
        return result;
    }

   
}
