using HealthWomen.Communication.RequestDTO.Woman.Register;
using HealthWomen.Communication.ResponseDTO.Woman.Register;
using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using Mapster;

namespace HealthWomen.Application.UseCase.WomanUseCase.Register;
/// <summary>
/// Regra de negócio.
/// </summary>
public class RegisterWomanUseCase : IRegisterWomanUseCase
{
    private readonly IWomenCommand _womanCommand;
    private readonly IWomenQuery _womanQuery;
    private readonly ISaveChangesCommand _saveChanges;
    public RegisterWomanUseCase(IWomenCommand womanCommand, IWomenQuery womanQuery, ISaveChangesCommand saveChanges)
    {
        _womanCommand = womanCommand;
        _womanQuery = womanQuery;
        _saveChanges = saveChanges;
    }

    /// <summary>
    /// Método para registrar um mulher no banco de dados
    /// </summary>
    /// <param name="register">Dados enviados pela request</param>
    /// <returns>Retorno do registro</returns>
    /// <exception cref="Exception"></exception>
    public async Task<ResponseWomanDTO> ExecuteAsync(RegisterWomanDTO register)
    {
        var existingName = await _womanQuery.GetByName(register.WomanName!);
        if (existingName)
            throw new Exception($"Registro cancelado, o nome digitado, {register.WomanName}, existe no banco de dados");

        if (register.ContainsExistingDiseases!.Equals("Sim", StringComparison.CurrentCultureIgnoreCase) && (register.DiseaseName is null || register.DiseaseName.Count is 0))
            throw new Exception("Registro cancelado, você informou que possui doenças existentes, mas não listou nenhuma doença.");

        var womanMapping = register.Adapt<Women>();

        if (register.ContainsExistingDiseases!.Equals("Não", StringComparison.CurrentCultureIgnoreCase))
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
        womanMapping.Diseases = [.. register.DiseaseName!.Select(nameDiseases => new Diseases { DiseaseName = nameDiseases })];

        await _womanCommand.AddWoman(womanMapping);
        await _saveChanges.Save();

        return new ResponseWomanDTO
        {
            Id = womanMapping.Id,
            ReturnMessage = "Registro efetuado com sucesso!"
        };
    }
}
