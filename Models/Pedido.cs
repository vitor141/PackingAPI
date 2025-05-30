
namespace PackingAPI.Models;

public class Pedido
{
    public int Id { get; set; }
    public List<Produto> Produtos { get; set; } = new();
    public List<CaixaUsada> CaixasUsadas { get; set; } = new();
}
