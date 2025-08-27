using HealthWoman.Communication.ResponseDTO.AwarenessMonth.Get;
using HealthWoman.Domain.Repositories;
using Mapster;
using MapsterMapper;

namespace HealthWoman.Application.UseCase.AwarenessMonthUseCase.Get;

public class GetAwarenessMonthUseCase : IGetAwarenessMonthUseCase
{
    private readonly IAwarenessMonthQuery _awarenessQuery;


    public GetAwarenessMonthUseCase(IAwarenessMonthQuery awarenessQuery)
    {
        _awarenessQuery = awarenessQuery;
    }

    public async Task<ResponseListAwarenessMonthDTO> GetExecute()
    {
        var awarenessMonths = await _awarenessQuery.GetAwarenessMonth();
        if (awarenessMonths.Count is 0)
            throw new Exception("Nenhum mês de conscientização encontrado no banco de dados.");

        var response = awarenessMonths.Adapt<List<ResponseAwarenessMonthDTO>>();
        return new ResponseListAwarenessMonthDTO { AwarenessMonths = response };

    }
}
