using PackingAPI.Models;

namespace PackingAPI.Services;

public class PackingService
{
    private readonly List<Caixa> _caixasDisponiveis = new()
    {
        new Caixa { Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
        new Caixa { Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
        new Caixa { Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
    };

    public List<CaixaUsada> EmpacotarProdutos(List<Produto> produtos)
    {
        var produtosRestantes = new List<Produto>(produtos);
        var caixasUsadas = new List<CaixaUsada>();

        while (produtosRestantes.Any())
        {
            foreach (var caixa in _caixasDisponiveis.OrderBy(c => c.Volume))
            {
                var produtosNaCaixa = new List<Produto>();
                var volumeDisponivel = caixa.Volume;

                foreach (var produto in produtosRestantes.ToList())
                {
                    if (caixa.Cabe(produto) && produto.Volume <= volumeDisponivel)
                    {
                        produtosNaCaixa.Add(produto);
                        volumeDisponivel -= produto.Volume;
                        produtosRestantes.Remove(produto);
                    }
                }

                if (produtosNaCaixa.Any())
                {
                    caixasUsadas.Add(new CaixaUsada
                    {
                        NomeCaixa = caixa.Nome,
                        Produtos = produtosNaCaixa
                    });
                    break;
                }
            }
        }

        return caixasUsadas;
    }
}
