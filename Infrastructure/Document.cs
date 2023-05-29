using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthApi.Infrastructure;


public abstract class Document : IDocument
{   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt => DateTime.Now;
}