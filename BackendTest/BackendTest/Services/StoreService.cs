using BackendTest.Interfaces;
using BackendTest.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BackendTest.Services
{
    public class StoreService : IStoreService
    {
        private readonly IMongoCollection<Store> _storesCollection;

        public StoreService(IOptions<CafeDatabaseSettings> cafeDatabaseSettings)
        {
            var mongoClient = new MongoClient(cafeDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(cafeDatabaseSettings.Value.DatabaseName);

            _storesCollection = mongoDatabase.GetCollection<Store>(cafeDatabaseSettings.Value.StoreCollectionName);
        }

        public async Task<Store> GetByLocationAsync(string location)
        {
            return await _storesCollection.Find(x => x.Location == location).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Store store)
        {
            store.Id = ObjectId.GenerateNewId().ToString();
            store.Location = store.Location.ToLower();

            var existingStore = await _storesCollection.Find(x => x.Location == store.Location).FirstOrDefaultAsync();

            if (existingStore != null)
            {
                throw new Exception("Error: Store already exist in that location.");
            }

            await _storesCollection.InsertOneAsync(store);
        }

    }
}
