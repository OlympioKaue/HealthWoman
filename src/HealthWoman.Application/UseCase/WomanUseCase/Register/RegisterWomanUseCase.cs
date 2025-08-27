using HealthWoman.Communication.RequestDTO.Woman.Register;
using HealthWoman.Communication.ResponseDTO.Woman.Register;
using HealthWoman.Domain.Entities;
using HealthWoman.Domain.Repositories;
using Mapster;
using System.Runtime.Intrinsics.X86;

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

        if (registerWoman.ContainsExistingDiseases!.ToLower() is "Sim" &&
          (registerWoman.DiseaseName is null || registerWoman.DiseaseName.Count is 0))
        {
            throw new Exception("Registro cancelado, você informou que possui doenças existentes, mas não listou nenhuma doença.");
        }

        var womanMapping = registerWoman.Adapt<Woman>();

        if (registerWoman.ContainsExistingDiseases!.Equals("Não", StringComparison.CurrentCultureIgnoreCase))
        {
            womanMapping.ContainsExistingDisease = "Não";
            await _womanCommand.AddWoman(womanMapping);
            await _saveChanges.Save();

            return new ResponseWomanDTO
            {
                Id = womanMapping.Id,
                ReturnMessage = "Registro efetuado com sucesso!"
            };

        }

        womanMapping.ContainsExistingDisease = "Sim";
        womanMapping.Diseases = registerWoman.DiseaseName!
        .Select(nameDiseases => new Diseases { DiseaseName = nameDiseases })
        .ToList();

        await _womanCommand.AddWoman(womanMapping);
        await _saveChanges.Save();

        return new ResponseWomanDTO
        {
            Id = womanMapping.Id,
            ReturnMessage = "Registro efetuado com sucesso!"
        };
    }
}
