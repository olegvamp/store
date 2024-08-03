using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NotShop.Models;
using NotShop.Models.Entities;
using NotShop.Models.Entity;
using Group = NotShop.Models.Group;

namespace NotShop.Controllers;

public class HomeController : Controller
{
    private readonly MongoDbService dbService;
    private readonly PgContext _pgContext;
    
    public HomeController(MongoDbService dbService, PgContext pgContext)
    {
        this.dbService = dbService;
        _pgContext = pgContext;
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

