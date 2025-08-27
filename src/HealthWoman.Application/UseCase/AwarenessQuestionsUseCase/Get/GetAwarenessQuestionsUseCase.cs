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

    public async Task<ResponseListAwarenessQuestionsDTO> GetExecute()
    {
        var tttttt = await _awarenessQuestionsQuery.GetAwarenessQuestions();

        var response = tttttt.Adapt<List<ResponseAwarenessQuestionsDTO>>();
        return new ResponseListAwarenessQuestionsDTO { AwarenessQuestions = response };
    }
}
