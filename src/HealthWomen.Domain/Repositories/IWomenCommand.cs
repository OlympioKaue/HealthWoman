using HealthWomen.Domain.Entities;

namespace HealthWomen.Domain.Repositories;

public interface IWomenCommand
{
    Task AddWoman(Woman addWoman);
    void UpdateWoman(Woman updateWoman);
}
