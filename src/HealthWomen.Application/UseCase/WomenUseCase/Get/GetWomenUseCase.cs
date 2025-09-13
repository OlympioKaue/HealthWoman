using HealthWomen.Communication.ResponseDTO.StatisticalData.Get;
using HealthWomen.Communication.ResponseDTO.Woman.Get;
using HealthWomen.Domain.Repositories;
using Mapster;
using OpenAI.Chat;

namespace HealthWomen.Application.UseCase.WomanUseCase.Get;

/// <summary>
/// Regra de negócio.
/// </summary>
public class GetWomanUseCase : IGetWomanUseCase
{
    private readonly IWomenQuery _woman;
    public GetWomanUseCase(IWomenQuery woman)
    {
        _woman = woman;
    }

    /// <summary>
    /// Método para buscar dados cadastrados
    /// </summary>
    /// <returns>Retorno dos dados cadastrados</returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResponseGetListWomanDTO> GetAllExecute()
    {
        //Retorno selecionado (Id, Nome)
        var resultSelected = await _woman.GetSelectedItem(x => new ResponseGetWomanDTO
        {
            Id = x.Id,
            WomanName = x.WomanName,
        });

        var tt = resultSelected.Adapt<ResponseGetListWomanDTO>();
        
        if (tt.listWoman.Count is 0)
            throw new Exception("Nenhuma mulher cadastrada no banco de dados.");

        return new ResponseGetListWomanDTO { listWoman = tt.listWoman };

    }

    /// <summary>
    /// Método para buscar dados filtrados pelo ID
    /// </summary>
    /// <param name="id">Parâmetro enviado via Rota</param>
    /// <returns>Retorne os dados cadastrados, filtrando pelo ID.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResponseGetAllWomanDTO> GetByIdExecute(int id)
    {
        //Retorno selecionado, filtrando pelo ID.
        var resultSelectedByID = await _woman.GetById(id);
        if (resultSelectedByID is null)
            throw new Exception("Não existe cadastro de mulher com esse Id.");

        var response = resultSelectedByID.Adapt<ResponseGetAllWomanDTO>();
        return response;
    }


}
