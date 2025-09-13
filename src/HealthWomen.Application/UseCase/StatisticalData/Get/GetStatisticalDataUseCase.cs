using HealthWomen.Communication.ResponseDTO.StatisticalData.Get;
using HealthWomen.Domain.Repositories;

namespace HealthWomen.Application.UseCase.StatisticalData.Get;

public class GetStatisticalDataUseCase : IGetStatisticalDataUseCase
{
    private readonly IStatisticalDataQuery _statisticalDataQuery;
    public GetStatisticalDataUseCase(IStatisticalDataQuery statisticalDataQuery)
    {
        _statisticalDataQuery = statisticalDataQuery;
    }
    public async Task<ResponseStatisticalDataWoman> GetExecute()
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


        var resultDoencas = queryWomanDb
        .Where(x => x.Diseases != null && x.Diseases.Any()).SelectMany(x => x.Diseases)
        .GroupBy(d => d.DiseaseName)
        .Select(g => new ResponseDiseasesStatisticalDataWoman
        {
            DiseaseName = g.Key,
            MostCommonComorbidities = g.Count(),
        })
        .ToList();


        return new ResponseStatisticalDataWoman
        {
            TotalNumberOfRegisteredWoman = totalWoman,
            TotalPapSmearRecommendations = papSmearRecommendations,
            TotalNumberOfWomenWithExistingComorbidities = womenWithComorbidities,
            Comorbidities = resultDoencas
        };
    }


}
