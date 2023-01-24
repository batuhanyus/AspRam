using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Classico.Models;

namespace Classico.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var res = $"{GC.GetTotalMemory(false) / 1024 / 1024} MB (managed)"
                  + Environment.NewLine +
                  $"System: {Environment.WorkingSet / 1024 / 1024} MB (total)";

        ViewBag.RAM = res;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}