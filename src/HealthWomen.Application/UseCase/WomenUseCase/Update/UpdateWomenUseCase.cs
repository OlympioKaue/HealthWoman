using HealthWomen.Communication.ResponseDTO.Woman.Register;
using HealthWomen.Communication.RequestDTO.Woman.Register;
using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using Mapster;

namespace HealthWomen.Application.UseCase.WomanUseCase.Update;

public class UpdateWomanUseCase : IUpdateWomanUseCase
{
    private readonly IWomenCommand _womanCommand;
    private readonly IWomenQuery _womanQuery;
    private readonly ISaveChangesCommand _save;
    public UpdateWomanUseCase(IWomenCommand womanCommand, IWomenQuery womanQuery, ISaveChangesCommand save)
    {
        _womanCommand = womanCommand;
        _womanQuery = womanQuery;
        _save = save;
    }
    public async Task UpdateExecute(UpdateWomanDTO update, int id)
    {
        var mapping = update.Adapt<Women>();
        var getById = await _womanQuery.GetById(id);
        if (getById is null)
            throw new Exception($"Atualização cancelada, o id fornecido não existe");

        _womanCommand.UpdateWoman(mapping);
        await _save.Save();

    }
}
