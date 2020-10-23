using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountdownWatcherApi.Models
{
    public class CountdownWatcherDatabaseSettings : ICountdownWatcherDatabaseSettings
    {
        public string CountdownEventCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
