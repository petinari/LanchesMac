using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class ContatoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}