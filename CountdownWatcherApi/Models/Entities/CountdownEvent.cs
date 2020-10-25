using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CountdownWatcherApi.Models.Entities
{
    public class CountdownEvent : Auditable
    {
        public CountdownEvent(): base() {

        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [BsonElement("EventToken")]
        public string EventToken { get; set; }
        [Required]
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Description")]
        //[BsonIgnoreIfNull]
        public string Description { get; set; }
        [Required]
        [BsonElement("EventDate")]
        public DateTime EventDate { get; set; }

    }
}
