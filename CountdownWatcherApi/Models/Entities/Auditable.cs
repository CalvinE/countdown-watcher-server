using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CountdownWatcherApi.Models.Entities
{
    public abstract class Auditable
    {
        public Auditable()
        {
            CreatedDate = DateTime.UtcNow;
        }

        [Required]
        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("ModifiedById")]
        public string ModifiedById { get; set; }
        [BsonElement("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
