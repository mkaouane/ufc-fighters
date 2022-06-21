using WebApplication2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WebApplication2.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Fighters> _fightersCollection;
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);

            _fightersCollection = database.GetCollection<Fighters>(mongoDBSettings.Value.CollectionName);

        }

        public async Task<List<Fighters>> GetAsync() {
            return await _fightersCollection.Find(new BsonDocument()).ToListAsync();

        }
        public async Task CreateAsync(Fighters fighters) {
            await _fightersCollection.InsertOneAsync(fighters); 
        }
        public async Task AddToFightersAsync(string id, string fighterId) { }
        public async Task DeleteAsync(string id) { }


    }
}
