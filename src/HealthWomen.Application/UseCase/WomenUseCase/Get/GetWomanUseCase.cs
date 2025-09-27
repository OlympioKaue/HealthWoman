using HealthWomen.Communication.ResponseDTO.Women.Get;
using HealthWomen.Domain.Repositories;
using Mapster;

namespace HealthWomen.Application.UseCase.WomenUseCase.Get;

public class GetWomanUseCase : IGetWomanUseCase
{
    private readonly IWomenQuery _woman;
    public GetWomanUseCase(IWomenQuery woman)
    {
        _woman = woman;
    }

    public async Task<ResponseListWomen> GetAllExecute()
    {
        var result = await _woman
            .GetGenericData(x => new ResponseWomanDTO
            {
                Id = x.Id,
                WomanName = x.WomanName,
                Age = x.Age
            });

        if (result.Count is 0)
            throw new Exception("Nenhuma mulher cadastrada no banco de dados.");
        
        return new ResponseListWomen { ListWomen = result };
    }
   
}