using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NotShop.Models;
using NotShop.Models.Entity;

namespace NotShop.Controllers;

public class EditorController : Controller
{
    private readonly MongoDbService dbService;

    public EditorController(MongoDbService dbService)
    {
        this.dbService = dbService;
    }

    public IActionResult Index()
    {
        return View();
    }
}

