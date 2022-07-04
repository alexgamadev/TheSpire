using MongoDB.Driver;
using TheSpire.Models;

namespace TheSpire.Repositories
{
    public class TemporaryUsersRepo : ITemporaryUsersRepo
    {
        private readonly IMongoCollection<TemporaryUser> _tempUserData;

        public TemporaryUsersRepo(IElementalTowerDbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _tempUserData = database.GetCollection<TemporaryUser>(settings.TempUsersCollection);
        }

        public async Task<TemporaryUser?> CreateAsync(TemporaryUser newTempUser)
        {
            var existingUser = await _tempUserData.Find(tempUser => tempUser.DeviceIdentifier == newTempUser.DeviceIdentifier).FirstOrDefaultAsync();
            if (existingUser is not null)
            {
                return null;
            }
            await _tempUserData.InsertOneAsync(newTempUser);
            return newTempUser;
        }

        public async Task<List<TemporaryUser>> GetAllAsync()
        {
            return await _tempUserData.Find(tempUsers => true).ToListAsync();
        }

        public async Task<TemporaryUser?> GetAsync(string id)
        {
            var tempUser = await _tempUserData.Find(tempUser => tempUser.Id == id).FirstOrDefaultAsync();
            return tempUser;
        }

        public async Task RemoveAsync(string id)
        {
            await _tempUserData.DeleteOneAsync(tempUser => tempUser.Id == id);
        }

        public async Task UpdateAsync(string id, TemporaryUser updatedTempUser)
        {
            await _tempUserData.ReplaceOneAsync(tempUser => tempUser.Id == id, updatedTempUser);
        }
    }
}
