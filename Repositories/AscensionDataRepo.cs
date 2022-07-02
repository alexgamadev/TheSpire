using MongoDB.Driver;
using TheSpire.Models;

namespace TheSpire.Repositories;

public class AscensionDataRepo : IAscensionDataRepo
{
    private readonly IMongoCollection<AscensionData> _ascensionData;

    public AscensionDataRepo(IElementalTowerDbSettings dbSettings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(dbSettings.DatabaseName);
        _ascensionData = database.GetCollection<AscensionData>(dbSettings.AscensionRunsCollection);
    }

    public async Task<AscensionData> CreateAsync(AscensionData data)
    {
        await _ascensionData.Indexes.CreateOneAsync(new CreateIndexModel<AscensionData>(Builders<AscensionData>.IndexKeys.Ascending(_ => _.Duration)));

        await _ascensionData.InsertOneAsync(data);
        return data;
    }

    public async Task<AscensionData> GetAsync(string id)
    {
        return await _ascensionData.Find(data => data.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<AscensionData>> GetAllAsync()
    {
        return await _ascensionData.Find(data => true).ToListAsync();
    }

    public async Task<int> GetRankAsync(string id)
    {
        var sortedData = await _ascensionData.Find(data => true).SortBy(data => data.Duration).ToListAsync();
        if (sortedData is null)
        {
            return 1;
        }

        int rank = sortedData.FindIndex(data => data.Id == id);
        return rank + 1;
    }

    public async Task RemoveAsync(string id)
    {
        await _ascensionData.DeleteOneAsync(student => student.Id == id);
    }

    public async Task UpdateAsync(string id, AscensionData data)
    {
        await _ascensionData.ReplaceOneAsync(student => student.Id == id, data);
    }
}