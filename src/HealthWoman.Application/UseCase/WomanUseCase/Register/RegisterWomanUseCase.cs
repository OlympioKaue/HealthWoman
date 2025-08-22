using HealthWoman.Communication.RequestDTO.Woman.Register;
using HealthWoman.Communication.ResponseDTO.Woman.Register;
using HealthWoman.Domain.Entities;
using HealthWoman.Domain.Repositories;
using Mapster;
using MapsterMapper;

namespace HealthWoman.Application.UseCase.WomanUseCase.Register;

public class RegisterWomanUseCase : IRegisterWomanUseCase
{
    private readonly IWomanCommand _womanCommand;
    private readonly IWomanQuery _womanQuery;
    private readonly ISaveChangesCommand _saveChanges;
    public RegisterWomanUseCase(IWomanCommand womanCommand, IWomanQuery womanQuery, ISaveChangesCommand saveChanges)
    {
        _womanCommand = womanCommand;
        _womanQuery = womanQuery;
        _saveChanges = saveChanges;
    }

    public async Task<ResponseWomanDTO> RegisterExecute(RegisterWomanDTO registerWoman)
    {
        var thisNameExists = await _womanQuery.WomanExistsByThisName(registerWoman.WomanName!);
        if (thisNameExists)
            throw new Exception($"Registro cancelado, o nome digitado, {registerWoman.WomanName}, existe no banco de dados");

        var womanAdd = registerWoman.Adapt<Woman>();  
        await _womanCommand.AddWoman(womanAdd);
        await _saveChanges.Save();

        return new ResponseWomanDTO
        {
            Id = womanAdd.Id,
            ReturnMessage = "Registro efetuado com sucesso!"
        };

    }
}
