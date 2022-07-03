using MongoDB.Driver;
using TheSpire.Models;

namespace TheSpire.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly IMongoCollection<Account> _accountData;

        public AccountRepo(IElementalTowerDbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _accountData = database.GetCollection<Account>(settings.AccountsCollection);
        }

        public async Task<Account> CreateAsync(Account newAccount)
        {
            await _accountData.InsertOneAsync(newAccount);
            return newAccount;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _accountData.Find(accounts => true).ToListAsync();
        }

        public async Task<Account> GetAsync(string id)
        {
            var account = await _accountData.Find(account => account.Id == id).FirstOrDefaultAsync();
            return account;
        }

        public async Task RemoveAsync(string id)
        {
            await _accountData.DeleteOneAsync(account => account.Id == id);
        }

        public async Task UpdateAsync(string id, Account updatedAccount)
        {
            await _accountData.ReplaceOneAsync(account => account.Id == id, updatedAccount);
        }
    }
}
