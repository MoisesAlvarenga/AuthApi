using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthApi.Infrastructure;

public interface IDocument
{
    string Id { get; set; }
    DateTime CreatedAt { get; }
}