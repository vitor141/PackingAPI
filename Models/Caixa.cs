
namespace PackingAPI.Models;

public class Caixa
{
    public string Nome { get; set; } = string.Empty;
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }

    public int Volume => Altura * Largura * Comprimento;

    public bool Cabe(Produto p)
    {
        return (p.Altura <= Altura && p.Largura <= Largura && p.Comprimento <= Comprimento);
    }
}
