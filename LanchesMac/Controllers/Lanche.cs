using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class Lanche : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}