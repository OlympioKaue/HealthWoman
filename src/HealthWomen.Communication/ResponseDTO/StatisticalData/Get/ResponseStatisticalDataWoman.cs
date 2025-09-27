namespace HealthWomen.Communication.ResponseDTO.StatisticalData.Get;

public class ResponseStatisticalDataWoman
{
    public int TotalNumberOfRegisteredWoman { get; set; }
    public int TotalPapSmearRecommendations { get; set; }
    public int TotalNumberOfWomenWithExistingComorbidities { get; set; }
    public List<ResponseDiseasesStatisticalDataWoman> Comorbidities { get; set; } = [];
}
