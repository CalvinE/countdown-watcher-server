namespace CountdownWatcherApi.Models
{
    public interface ICountdownWatcherDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CountdownEventCollectionName { get; set; }
    }
}