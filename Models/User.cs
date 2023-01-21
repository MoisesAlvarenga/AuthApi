using AuthApi.Infrastructure;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthApi.Models;

[BsonCollection("user")]
public class User : Document
{
    [BsonElement("email")]
    public string Email { get; set; }
    [BsonElement("password")]
    public string Password { get; set; }
}