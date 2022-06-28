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

    public AscensionData Create(AscensionData data)
    {
        _ascensionData.InsertOne(data);
        return data;
    }

    public AscensionData Get(string id)
    {
        return _ascensionData.Find(data => data.Id == id).FirstOrDefault();
    }

    public List<AscensionData> GetAll()
    {
        return _ascensionData.Find(data => true).ToList();
    }

    public int GetRank(string id)
    {
        var sortedData = _ascensionData.Find(data => true).SortBy(data => data.Duration).ToList();
        int rank = sortedData.FindIndex(data => data.Id == id);
        return rank + 1;
    }

    public void Remove(string id)
    {
        _ascensionData.DeleteOne(student => student.Id == id);
    }

    public void Update(string id, AscensionData data)
    {
        _ascensionData.ReplaceOne(student => student.Id == id, data);
    }
}