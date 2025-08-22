namespace HealthWoman.Domain.Repositories;

public interface IWomanQuery
{
    Task<bool> WomanExistsByThisName(string womanName);
}
