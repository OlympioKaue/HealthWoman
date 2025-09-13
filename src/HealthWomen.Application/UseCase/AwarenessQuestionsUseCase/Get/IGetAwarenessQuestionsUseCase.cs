using HealthWomen.Application.Reflection;
using HealthWomen.Communication.ResponseDTO.AwarenessQuestions.Get;

namespace HealthWomen.Application.UseCase.AwarenessQuestionsUseCase.Get;

public interface IGetAwarenessQuestionsUseCase : IGenericApplication
{
    Task<ResponseListAwarenessQuestionsDTO> GetAllExecute();
    Task<ResponseGetByIdAwarenessQuestionsDTO> GetByIdExecute(int id); 
   
}
