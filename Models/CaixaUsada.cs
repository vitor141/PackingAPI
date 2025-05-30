using System.ComponentModel.DataAnnotations.Schema;

namespace PackingAPI.Models;

public class Pedido
{
    public int Id { get; set; }

    public List<Produto> Produtos { get; set; } = new();

    [NotMapped]
    public List<CaixaUsada> CaixasUsadas { get; set; } = new();  
}