using MongoDB.Driver;
using News.API.Mongodb.Entities;

namespace News.API.Mongodb.Data;

public class NewsContext : IMongoNewsContext
{
    public NewsContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        EditNews = database.GetCollection<EditorNews>("News");
        
    }
    public IMongoCollection<EditorNews> EditNews { get; }
}