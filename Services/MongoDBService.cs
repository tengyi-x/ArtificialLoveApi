using ArtificialLove.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ArtificialLove.Services;

public class MongoDBService {

    private readonly IMongoCollection<User> _userCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _userCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(User user) {
        await _userCollection.InsertOneAsync(user);
        return;
    }
    
    public async Task<User> GetAsync(string id) {
        var filter = Builders<User>.Filter.Eq("Id", id);
        return await _userCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(string id, User user) {
        FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
        await _userCollection.ReplaceOneAsync(filter, user);
        return;
    }
}