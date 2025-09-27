using HealthWomen.Communication.RequestDTO.Women.Register;
using HealthWomen.Communication.ResponseDTO.Women.Register;
using HealthWomen.Domain.Entities;
using HealthWomen.Domain.Repositories;
using Mapster;

namespace HealthWomen.Application.UseCase.WomenUseCase.Register;

public class RegisterWomanUseCase : IRegisterWomanUseCase
{
    private readonly IWomenCommand _womanCommand;
    private readonly IWomenQuery _womanQuery;
    private readonly ISaveChangesCommand _saveChanges;
    private const string ThereIsDisease = "Yes";
    private const string ThereIsNotDisease = "Not";
    
    public RegisterWomanUseCase(IWomenCommand womanCommand, IWomenQuery womanQuery, ISaveChangesCommand saveChanges)
    {
        _womanCommand = womanCommand;
        _womanQuery = womanQuery;
        _saveChanges = saveChanges;
    }

    /// <summary>
    /// Executa o método e passe os parâmetros enviados pelo usúario.
    /// </summary>
    /// <param name="requestRegister">dados enviado via request</param>
    public async Task<ResponseWomanDTO> ExecuteAsync(RegisterWomanDto requestRegister)
    {
        var isNameExisting = await _womanQuery.GetByName(requestRegister.WomanName!);
        if (isNameExisting)
            throw new Exception($"registration canceled, name entered, " +
                                $"{requestRegister.WomanName}, exists in database");

        var womanEntity = requestRegister.Adapt<Woman>();

        var diseaseStatus = ContainsDiseasesRegister(womanEntity.ContainsExistingDisease!);
        if (diseaseStatus is ThereIsDisease
            && (requestRegister.DiseaseName is null || requestRegister.DiseaseName.Count is 0))
            throw new Exception("registration canceled, you reports disease but there are no diseases listed.");

        womanEntity.ContainsExistingDisease = diseaseStatus;
        womanEntity.Diseases = requestRegister.DiseaseName
            .Select(nameDisease => new Diseases
            {
                DiseaseName = nameDisease
            })
            .ToList();
        
        await _womanCommand.AddWoman(womanEntity);
        await _saveChanges.Save();

        var responseDto = ResponseWomanDTO.Response(id: womanEntity.Id, returnMessage: "successful");
        return responseDto;
    }

    private static string ContainsDiseasesRegister(string diseaseRequests)
    {
        var result = diseaseRequests.Equals("Yes", StringComparison.CurrentCultureIgnoreCase)
            ? ThereIsDisease
            : ThereIsNotDisease;
        return result;
    }
}