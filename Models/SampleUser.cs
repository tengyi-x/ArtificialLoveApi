using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ArtificialLove.Models;

public class SampleUser {

    [BsonId]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    // [BsonElement("image")]
    // public ??? Image { get; set; }

    [BsonElement("bio")]
    public string Bio { get; set; }

    [BsonElement("hobbies")]
    public List<string>? Hobbies { get; set; }
}
