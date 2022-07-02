using TheSpire.Models;

namespace TheSpire.Repositories;

public interface IAscensionDataRepo
{
    Task<List<AscensionData>> GetAllAsync();
    Task<AscensionData> GetAsync(string id);
    Task<int> GetRankAsync(string id);
    Task<AscensionData> CreateAsync(AscensionData data);
    Task UpdateAsync(string id, AscensionData data);
    Task RemoveAsync(string id);
}