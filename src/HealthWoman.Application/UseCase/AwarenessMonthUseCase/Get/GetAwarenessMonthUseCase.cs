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

    public async Task<ResponseListAwarenessMonthDTO> GetAllExecute()
    {
        var awarenessMonths = await _awarenessQuery.GetAwarenessMonth();
        if (awarenessMonths.Count is 0)
            throw new Exception("Nenhum mês de conscientização encontrado no banco de dados.");

        var response = awarenessMonths.Adapt<List<ResponseAwarenessMonthDTO>>();
        return new ResponseListAwarenessMonthDTO { AwarenessMonths = response };
    }

    public async Task<ResponseAwarenessMonthDTO> GetByMonthNameExecute(string month)
    {
        var testestes = await _awarenessQuery.GetByIdAwarenessMonth(month);
        if (testestes is null)
            throw new Exception("Mês inválido. Os meses válidos são: Marco, Agosto e Outubro.");

        var response = testestes.Adapt<ResponseAwarenessMonthDTO>();
        return response;
    }
}
