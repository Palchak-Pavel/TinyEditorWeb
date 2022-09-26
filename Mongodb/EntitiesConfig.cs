using MongoDB.Bson.Serialization;
using News.API.Mongodb.Entities;

namespace News.API.Mongodb;

public class EntitiesConfig
{
    public static void Config()
    {
        BsonClassMap.RegisterClassMap<Mongodb.Entities.EditorNews>(x =>
        {
            x.SetIgnoreExtraElements(true);
        });
    }
}