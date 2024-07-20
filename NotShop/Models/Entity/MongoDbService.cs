using MongoDB.Driver;

namespace NotShop.Models.Entity;

public class MongoDbService
{
    private readonly IConfiguration configuration;
    private readonly IMongoDatabase database;

    public MongoDbService(IConfiguration configuration)
    {
        this.configuration = configuration;

        var connectionString = this.configuration.GetConnectionString("DbConnection");
        var mongoUrl = MongoUrl.Create(connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase? Database => database;
}