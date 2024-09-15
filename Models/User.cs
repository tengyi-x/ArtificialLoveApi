using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ArtificialLove.Models;

public class User {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public required string Name { get; set; }

    [BsonElement("username")]
    public string? UserName { get; set; }

    [BsonElement("email")]
    public string? Email { get; set; }

    [BsonElement("image")]
    public string? Image { get; set; } // string placeholder for now, change later

    [BsonElement("bio")]
    public string? Bio { get; set; }

    [BsonElement("hobbies")]
    public List<string>? Hobbies { get; set; }

    [BsonElement("liked")]
    public List<SampleUser>? liked { get; set; }
}
