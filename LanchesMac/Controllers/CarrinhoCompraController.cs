using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class CarrinhoCompraController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}