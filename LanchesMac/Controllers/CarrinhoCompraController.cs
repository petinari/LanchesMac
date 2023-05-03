using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class CarrinhoCompraController : Controller
{
    private readonly CarrinhoCompra _carrinhoCompra;

    private readonly ILancheRepository _lancheRepository;

    public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
    {
        _lancheRepository = lancheRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    // GET
    public IActionResult Index()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItens = itens;

        var carrinhoCompraViewModel = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };
        return View(carrinhoCompraViewModel);
    }

    // adiciona um item ao carrinho
    public RedirectToActionResult AdicionarItemNoCarrinhoCompra(string lancheId)
    {
        var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == new Guid(lancheId));

        if (lancheSelecionado != null) _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);

        return RedirectToAction("Index");
    }

    // remove um item do carrinho
    public RedirectToActionResult RemoverItemDoCarrinhoCompra(string lancheId)
    {
        var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == new Guid(lancheId));

        if (lancheSelecionado != null) _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);

        return RedirectToAction("Index");
    }
}