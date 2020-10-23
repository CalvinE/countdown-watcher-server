using CountdownWatcherApi.Models;
using CountdownWatcherApi.Models.Entities;
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

        public Task<List<CountdownEvent>> Get() => _events.Find(ce => true).ToListAsync();

        public Task<CountdownEvent> Get(string eventToken) => _events.Find(ce => ce.EventToken == eventToken).FirstOrDefaultAsync();
    }
}
