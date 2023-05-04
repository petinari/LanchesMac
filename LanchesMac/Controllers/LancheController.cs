using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

[Route("Lanche")]
public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;

    public LancheController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    [Route("")]
    [Route("{categoria}")]
    public IActionResult List(string categoria)
    {
        IEnumerable<Lanche> lanches;

        if (string.IsNullOrEmpty(categoria))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            categoria = "Todos os lanches";
        }
        else
        {
            lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                .OrderBy(l => l.Nome);
        }

        var lancheListViewModel = new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual = categoria
        };

        return View(lancheListViewModel);
    }

    // metodo para detalhes do lanche
    [Route("Details/{id}")]
    public IActionResult Details(string id)
    {
        var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == Guid.Parse(id));

        return View(lanche);
    }
}