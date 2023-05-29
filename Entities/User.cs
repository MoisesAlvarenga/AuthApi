using AuthApi.Infrastructure;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthApi.Entities;

[BsonCollection("user")]
public class User : Document
{   
    [BsonElement("email")]
    public string? Email { get; set; }
    
    [BsonElement("firstName")]
    public string? FirstName { get; set; }

    [BsonElement("lastName")]
    public string? LastName { get; set; }

    [BsonElement("registrationDocument")]
    public string? RegistrationDocument { get; set; }

    [BsonElement("passwordHash")]
    public string? PasswordHash { get; set; }
}