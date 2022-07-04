using TheSpire.Models;

namespace TheSpire.Repositories
{
    public interface ITemporaryUsersRepo
    {
        public Task<TemporaryUser?> GetAsync(string id);

        public Task<List<TemporaryUser>> GetAllAsync();

        public Task<TemporaryUser?> CreateAsync(TemporaryUser newTempUser);

        public Task UpdateAsync(string id, TemporaryUser updatedTempUser);

        public Task RemoveAsync(string id);
    }
}
