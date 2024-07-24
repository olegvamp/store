using MongoDB.Bson;
using MongoDB.Driver;
using NotShop.Models;

namespace StoreTest;

public class MongoTest
{
    private string dbUrl = "mongodb://localhost:27017/NotStoreDb";
    
    //[Theory]
    //[InlineData("home")]
    public void TestAddCategory(string categoryName)
    {
        var mongoUrl = MongoUrl.Create(dbUrl);
        var mongoClient = new MongoClient(mongoUrl);
        var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        
        var items = database.GetCollection<Item>("Items");
        var categories = database.GetCollection<Category>("Categories");
        var subCategories = database.GetCollection<SubCategory>("SubCategories");


        var newCategory = new Category() { Id = ObjectId.GenerateNewId().ToString(), Name = categoryName };
        var newSubCategories = new SubCategory[]
        {
            new SubCategory() { Category = newCategory, Id = ObjectId.GenerateNewId().ToString(), Name = "furniture" },
            new SubCategory() { Category = newCategory, Id = ObjectId.GenerateNewId().ToString(), Name = "crockery" },
            new SubCategory() { Category = newCategory, Id = ObjectId.GenerateNewId().ToString(), Name = "textile" },
            new SubCategory() { Category = newCategory, Id = ObjectId.GenerateNewId().ToString(), Name = "light" },
            new SubCategory() { Category = newCategory, Id = ObjectId.GenerateNewId().ToString(), Name = "decor" }
        };

        var newItem = new Item()
        {
            Category = newCategory,
            Description = "Тарелка для еды",
            Id = ObjectId.GenerateNewId().ToString(),
            Name = "Westman plate",
            Price = 500,
            SubCategory = newSubCategories[1]

        };
          
        categories.InsertOne(newCategory);
        subCategories.InsertMany(newSubCategories);
        items.InsertOne(newItem);
    }
}