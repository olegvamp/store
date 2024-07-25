using MongoDB.Bson;
using MongoDB.Driver;
using NotShop.Models;

namespace StoreTest;

public class MongoTest
{
    private string dbUrl = "mongodb://localhost:27017/NotStoreDb";
    
    //[Theory]
    //[InlineData("home")]
    public void TestAddGroup(string groupName)
    {
        var mongoUrl = MongoUrl.Create(dbUrl);
        var mongoClient = new MongoClient(mongoUrl);
        var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);

        var group = new Group() { Id = ObjectId.GenerateNewId().ToString(), Name = groupName };
        database.GetCollection<Group>("Groups").InsertOne(group);
    }
    
    //[Theory]
    //[InlineData("home", "crockery")]
    public void TestAddCategory(string groupName, string сategoryName)
    {
        var mongoUrl = MongoUrl.Create(dbUrl);
        var mongoClient = new MongoClient(mongoUrl);
        var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        
        var group = database.GetCollection<Group>("Groups").Find(x => x.Name == groupName).FirstOrDefault();

        if (group is not null)
        {
            var category = new Category() { Group = group, Id = ObjectId.GenerateNewId().ToString(), Name = сategoryName};
            database.GetCollection<Category>("Categories").InsertOne(category);
        }
    }
    
    //[Theory]
    //[InlineData("home", "crockery", "Тарелки")]
    public void TestAddSubCategory(string groupName, string categoryName, string subCategoryName)
    {
        var mongoUrl = MongoUrl.Create(dbUrl);
        var mongoClient = new MongoClient(mongoUrl);
        var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        
        var group = database.GetCollection<Group>("Groups").Find(x => x.Name == groupName).FirstOrDefault();

        if (group is not null)
        {
            var category = database.GetCollection<Category>("Categories").Find(x => x.Group.Name == groupName && x.Name == categoryName).FirstOrDefault();
            if (category is not null)
            {
                database.GetCollection<SubCategory>("SubCategories").InsertOne(new SubCategory()
                {
                    Category = category, Id = ObjectId.GenerateNewId().ToString(), Name = subCategoryName
                });
            }
        }
    }
    
    //[Theory]
    //[InlineData("home", "crockery", "Тарелки")]
    public void TestAddItems(string groupName, string categoryName, string subCategoryName)
    {
        var mongoUrl = MongoUrl.Create(dbUrl);
        var mongoClient = new MongoClient(mongoUrl);
        var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        
        var group = database.GetCollection<Group>("Groups").Find(x => x.Name == groupName).FirstOrDefault();

        if (group is not null)
        {
            var category = database.GetCollection<Category>("Categories").Find(x => x.Group.Name == groupName && x.Name == categoryName).FirstOrDefault();
            if (category is not null)
            {
                var subcategory = database.GetCollection<SubCategory>("SubCategories").Find(x => x.Name == subCategoryName).FirstOrDefault();

                if (subcategory is not null)
                {
                    var item = new Item()
                    {
                        Group = group,
                        Category = category,
                        Description = "Тарелка для еды",
                        Id = ObjectId.GenerateNewId().ToString(),
                        Name = "Westman Plate",
                        Price = 500,
                        SubCategory = subcategory
                    };
                    database.GetCollection<Item>("Items").InsertOne(item);
                }
            }
        }
    }
    
    //[Theory]
    //[InlineData("Westman Plate")]
    public void TestAddImages(string itemName)
    {
        var mongoUrl = MongoUrl.Create(dbUrl);
        var mongoClient = new MongoClient(mongoUrl);
        var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);

        var item = database.GetCollection<Item>("Items").Find(x => x.Name == itemName).FirstOrDefault();
        
        database.GetCollection<Image>("Images").InsertOne(new Image()
        {
            Item = item,
            Id = ObjectId.GenerateNewId().ToString(),
            IsMain = true,
            Url = "/pictures/crockery/westman-plate/top.jpg"
        });
        
        database.GetCollection<Image>("Images").InsertOne(new Image()
        {
            Item = item,
            Id = ObjectId.GenerateNewId().ToString(),
            IsMain = false,
            Url = "/pictures/crockery/westman-plate/bottom.jpg"
        });
    }
}