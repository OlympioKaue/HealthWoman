using HealthWomen.Communication.ResponseDTO.Women.Get;
using HealthWomen.Domain.Repositories;
using Mapster;
namespace HealthWomen.Application.UseCase.WomenUseCase.GetByID;

public class GetWomenByIdUseCase : IGetWomenByIdUseCase
{
    private readonly IWomenQuery _woman;
    
    public GetWomenByIdUseCase(IWomenQuery woman)
    {
        _woman = woman;
    }
    public async Task<ResponseGetAllWomanDTO> GetByIdExecute(int id)
    {
        var result = await _woman.GetWomanById(id);
        if (result is null)
            throw new Exception("Não existe cadastro de mulher com esse Id.");

        var response = result.Adapt<ResponseGetAllWomanDTO>();
        return response;
    }
}