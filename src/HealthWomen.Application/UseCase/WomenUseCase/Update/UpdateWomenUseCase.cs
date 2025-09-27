using HealthWomen.Communication.RequestDTO.Women.Register;
using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using Mapster;

namespace HealthWomen.Application.UseCase.WomenUseCase.Update;

public class UpdateWomanUseCase : IUpdateWomanUseCase
{
    private readonly IWomenCommand _womanCommand;
    private readonly IWomenQuery _womanQuery;
    private readonly ISaveChangesCommand _save;

    public UpdateWomanUseCase
        (IWomenCommand womanCommand, IWomenQuery womanQuery, ISaveChangesCommand save)
    {
        _womanCommand = womanCommand;
        _womanQuery = womanQuery;
        _save = save;
    }

    public async Task UpdateExecute(UpdateWomanDTO updateRequest, int id)
    {
        var womanEntity = updateRequest.Adapt<Woman>();
        var getById = await _womanQuery.GetWomanById(id);
        if (getById is null)
            throw new Exception($"Atualização cancelada, o id fornecido não existe");
        
        _womanCommand.UpdateWoman(womanEntity);
        await _save.Save();
    }
}