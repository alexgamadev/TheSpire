using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSpire.Models;

[BsonIgnoreExtraElements]
public class AscensionData
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

    [BsonElement("duration")]
    public float Duration { get; set; }

    public int? Rank { get; set; }
}