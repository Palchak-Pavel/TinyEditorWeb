using News.API.Mongodb.Entities;
using MongoDB.Driver;

namespace News.API.Mongodb.Data;

public interface IMongoNewsContext
{
    IMongoCollection<EditorNews> EditNews { get; }
}