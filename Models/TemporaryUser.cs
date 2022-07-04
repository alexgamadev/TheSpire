using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSpire.Models
{
    public class TemporaryUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("device_identifier")]
        [BsonRequired]
        public string DeviceIdentifier { get; set; } = "";
    }
}
