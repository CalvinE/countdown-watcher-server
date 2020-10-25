using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CountdownWatcherApi.Models.Entities
{
    public abstract class Auditable
    {
        public Auditable()
        {
            CreatedDate = DateTime.UtcNow;
        }

        [JsonIgnore]
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonIgnore]
        [BsonElement("ModifiedById")]
        public string ModifiedById { get; set; }

        [JsonIgnore]
        [BsonElement("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
