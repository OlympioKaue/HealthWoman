using HealthWomen.Communication.ResponseDTO.StatisticalData.Get;
using HealthWomen.Domain.Repositories;

namespace HealthWomen.Application.UseCase.StatisticalData.Get;
/// <summary>
/// Classe da regra de negócio
/// </summary>
public class GetStatisticalDataUseCase : IGetStatisticalDataUseCase
{
    private readonly IStatisticalDataQuery _statisticalDataQuery;
    public GetStatisticalDataUseCase(IStatisticalDataQuery statisticalDataQuery)
    {
        _statisticalDataQuery = statisticalDataQuery;
    }
    /// <summary>
    /// Executar método da regra de negócio
    /// </summary>
    /// <returns>Retorno dos dados estatíticos</returns>
    public async Task<ResponseStatisticalDataWoman> GetStaticalExecute()
    {
        int totalWoman = 0;
        int papSmearRecommendations = 0;
        int womenWithComorbidities = 0;

        var queryWomanDb = await _statisticalDataQuery.GetStatisticalDataAsync();
        foreach (var woman in queryWomanDb)
        {
            totalWoman++;

            if (woman.Age >= 25 && woman.Age <= 64) papSmearRecommendations++;

            if (woman.ContainsExistingDisease?.Equals("sim", StringComparison.OrdinalIgnoreCase) == true) womenWithComorbidities++;
        }
            
        //Versão melhorada  
        var resultDoencas = queryWomanDb.Where(w => w.Diseases?.Any() == true)
            .SelectMany(w => w.Diseases)
            .Where(s => !string.IsNullOrWhiteSpace(s.DiseaseName))
            .GroupBy(d => d.DiseaseName)
            .Select(g => new ResponseDiseasesStatisticalDataWoman
            {
                DiseaseName = g.Key,
                MostCommonComorbidities = g.Count()

            }).ToList();


        return new ResponseStatisticalDataWoman
        {
            TotalNumberOfRegisteredWoman = totalWoman,
            TotalPapSmearRecommendations = papSmearRecommendations,
            TotalNumberOfWomenWithExistingComorbidities = womenWithComorbidities,
            Comorbidities = resultDoencas
        };
    }


}
