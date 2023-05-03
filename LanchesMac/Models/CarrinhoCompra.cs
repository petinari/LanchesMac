using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models;

public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext contexto)
    {
        _context = contexto;
    }


    public Guid CarrinhoCompraId { get; set; }
    public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public static CarrinhoCompra GetCarrinho(IServiceProvider serviceProvider)
    {
        var session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext?.Session;

        var context = serviceProvider.GetService<AppDbContext>();

        var carrinhoCompraId = session.GetString("CarrinhoCompraId") ?? Guid.NewGuid().ToString();

        session.SetString("CarrinhoCompraId", carrinhoCompraId);

        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = Guid.Parse(carrinhoCompraId)
        };
    }

    // adiciona um item ao carrinho
    public void AdicionarAoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem =
            _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Lanche = lanche,
                Quantidade = 1
            };

            _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }

        _context.SaveChanges();
    }

    // remove um item do carrinho
    public int RemoverDoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem =
            _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

        var quantidadeLocal = 0;

        if (carrinhoCompraItem != null)
        {
            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }
        }

        _context.SaveChanges();

        return quantidadeLocal;
    }

    // retorna todos os itens do carrinho
    public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
    {
        return CarrinhoCompraItens ??= _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Include(s => s.Lanche)
            .ToList();
    }

    //soma o total do carrinho
    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
        return total;
    }
}