namespace LanchesMac.Models;

public class CarrinhoCompraItem
{
    public Guid CarrinhoCompraItemId { get; set; }
    public Lanche Lanche { get; set; }
    public int Quantidade { get; set; }
    public Guid CarrinhoCompraId { get; set; }
}