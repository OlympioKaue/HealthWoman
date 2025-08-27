using HealthWoman.Application.Reflection;
using HealthWoman.Communication.ResponseDTO.AwarenessQuestions.Get;

namespace HealthWoman.Application.UseCase.AwarenessQuestionsUseCase.Get;

public interface IGetAwarenessQuestionsUseCase : IGenericApplication
{
    Task<ResponseListAwarenessQuestionsDTO> GetExecute();
}
