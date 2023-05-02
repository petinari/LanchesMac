using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class LancheController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}