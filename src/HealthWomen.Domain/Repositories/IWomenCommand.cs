using HealthWomen.Domain.Entities;

namespace HealthWomen.Domain.Repositories;

public interface IWomenCommand
{
    Task AddWoman(Women addWoman);
    void UpdateWoman(Women updateWoman);
}
