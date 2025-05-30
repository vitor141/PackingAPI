
namespace PackingAPI.Models;

public class Produto
{
    public int Id { get; set; }
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }

    public int Volume => Altura * Largura * Comprimento;
}
