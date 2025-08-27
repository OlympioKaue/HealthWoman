using HealthWoman.Domain.Entities;

namespace HealthWoman.Domain.Repositories;

public interface IAwarenessQuestionsQuery
{
    Task<List<AwarenessQuestions>> GetAwarenessQuestions();
}
