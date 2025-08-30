using HealthWoman.Communication.ResponseDTO.Woman.Get;
using HealthWoman.Domain.Repositories;
using Mapster;

namespace HealthWoman.Application.UseCase.WomanUseCase.Get;

public class GetWomanUseCase : IGetWomanUseCase
{
    private readonly IWomanQuery _woman;
    public GetWomanUseCase(IWomanQuery woman)
    {
        _woman = woman;
    }

    public async Task<ResponseGetListWomanDTO> GetAllExecute()
    {
        var result = await _woman.GetAllWoman(x => new ResponseGetWomanDTO
        {
            Id = x.Id,
            WomanName = x.WomanName,
        });

        if (result.Count is 0)
            throw new Exception("Nenhuma mulher cadastrada no banco de dados.");

        return new ResponseGetListWomanDTO { listWoman = result };

    }

    public async Task<ResponseGetAllWomanDTO> GetByIdExecute(int id)
    {
        var result = await _woman.GetById(id);
        if (result is null)
            throw new Exception("Não existe cadastro de mulher com esse Id.");

        var response = result.Adapt<ResponseGetAllWomanDTO>();
        return response;
    }
}
