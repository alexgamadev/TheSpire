using TheSpire.Models;

namespace TheSpire.Repositories;

public interface IAscensionDataRepo
{
    List<AscensionData> GetAll();
    AscensionData Get(string id);
    int GetRank(string id);
    AscensionData Create(AscensionData data);
    void Update(string id, AscensionData data);
    void Remove(string id);
}