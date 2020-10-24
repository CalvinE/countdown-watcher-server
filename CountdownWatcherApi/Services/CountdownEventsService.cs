using CountdownWatcherApi.Models;
using CountdownWatcherApi.Models.Entities;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountdownWatcherApi.Services
{
    public class CountdownEventsService
    {
        private readonly IMongoCollection<CountdownEvent> _events;

        public CountdownEventsService(ICountdownWatcherDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _events = database.GetCollection<CountdownEvent>(settings.CountdownEventCollectionName);
        }

        public async Task<List<CountdownEvent>> Get()
        {
            var results = await _events.Find(ce => true).ToListAsync();
            return results;
        }

        public async Task<CountdownEvent> Get(string id)
        {
            var results = await _events.Find(ce => ce.Id == id).FirstOrDefaultAsync();
            return results;
        }

        public async Task<CountdownEvent> GetByEventToken(string eventToken)
        {
            var results = await _events.Find(ce => ce.EventToken == eventToken).FirstOrDefaultAsync();
            return results;
        }

        public async Task<CountdownEvent> Create(CountdownEvent ce) {
            await _events.InsertOneAsync(ce);
            return ce;
        }

        public async Task Update(string id, CountdownEvent ce)
        {
            await _events.ReplaceOneAsync(cevent => cevent.Id == id, ce);
        }

        public async Task Remove(CountdownEvent ce)
        {
            await _events.DeleteOneAsync(cevent => cevent.Id == ce.Id);
        }

        public async Task Remove(string id)
        {
            await _events.DeleteOneAsync(cevent => cevent.Id == id);
        }

        public async Task RemoveByEventToken(CountdownEvent ce)
        {
            await _events.DeleteOneAsync(cevent => cevent.EventToken == ce.EventToken);
        }

    }
}
