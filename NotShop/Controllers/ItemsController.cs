using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NotShop.Models;
using NotShop.Models.Entity;

namespace NotShop.Controllers;

public class ItemsController : Controller
{
    private readonly MongoDbService dbService;

    public ItemsController(MongoDbService dbService)
    {
        this.dbService = dbService;
    }

    [Route("Items/List/{category}")]
    public ViewResult List(string category)
    {
        IEnumerable<Item> items;
        if(string.IsNullOrEmpty(category))
        {
            items = dbService.Database.GetCollection<Item>("Items").Find(x => x.Name != "").ToList();
        }
        else
        {
            items = dbService.Database.GetCollection<Item>("Items").Find(x => x.Category.Name == category).ToList();
        }

        return View(items);
    }
}

