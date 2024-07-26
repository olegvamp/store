using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NotShop.Models;
using NotShop.Models.Entity;

namespace NotShop.Controllers;

public class HomeController : Controller
{
    private readonly MongoDbService dbService;

    public HomeController(MongoDbService dbService)
    {
        this.dbService = dbService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Categories()
    {
        return View(dbService.Database.GetCollection<Group>("Categories").Find(x => x.Name != "").ToList());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

