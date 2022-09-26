using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using News.API.Common;
using News.API.Mongodb.ValueObjects;

namespace News.API.Mongodb.Entities;

[BsonIgnoreExtraElements]
public class EditorNews : EntityBase
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string? Id { get; set; } 
    public string Title { get; set; }
    public string Url { get; set; } = null!;
    public string H1 { get; set; } = null!;
    public string Description { get; set; }
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    
    public DateTime CreatedAt { get; set; }
    public CreatedBy CreatedBy { get; set; } = null!;
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime LastModifiedAt { get; set; }
    
    public LastModifiedBy LastModifiedBy { get; set; } = null!;
    public string Content { get; set; } = null!;
}