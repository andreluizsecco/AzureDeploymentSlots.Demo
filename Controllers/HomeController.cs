using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AzureDeploymentSlots.Demo.Models;

namespace AzureDeploymentSlots.Demo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static string? _valorEmMemoria;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ValorEmMemoria = _valorEmMemoria;
        return View();
    }

    public IActionResult PreencherValorEmMemoria()
    {
        _valorEmMemoria = $"Preenchido em {DateTime.Now}";
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
