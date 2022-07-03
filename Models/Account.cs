using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSpire.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("device_indentifier")]
        [BsonRequired]
        public string DeviceIdentifier { get; set; } = "";

        [BsonElement("username")]
        [BsonRequired]
        public string Username { get; set; } = "";
    }
}
