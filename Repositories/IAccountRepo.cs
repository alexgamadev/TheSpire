using TheSpire.Models;

namespace TheSpire.Repositories
{
    public interface IAccountRepo
    {
        public Task<Account> GetAsync(string id);

        public Task<List<Account>> GetAllAsync();

        public Task<Account> CreateAsync(Account newAccount);

        public Task UpdateAsync(string id, Account updatedAccount);

        public Task RemoveAsync(string id);
    }
}
