using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using News.API.Mongodb.ValueObjects;

namespace News.API.DTO;

public class NewsDto
{
    /*public NewsDTO(string id, string title, string url, string h1, string description, DateTime createdAt, DateTime lastModifiedAt, string content)
    {
        Id = id;
        Title = title;
        Url = url;
        H1 = h1;
        Description = description;
        CreatedAt = createdAt;
        LastModifiedAt = lastModifiedAt;
        Content = content;
    }*/
        
        
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 
    
    public string Title { get; set; } 
    public string Url { get; set; }
    public string H1 { get; set; } 
    public string Description { get; set; } 

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]

    public DateTime CreatedAt { get; set; }

    public CreatedBy[] CreatedBy { get; set; } 

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]

    public DateTime LastModifiedAt { get; set; }

    public LastModifiedBy[] LastModifiedBy { get; set; } 
    public string Content { get; set; }
}