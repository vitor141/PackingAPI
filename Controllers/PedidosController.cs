
using Microsoft.AspNetCore.Mvc;
using PackingAPI.Models;
using PackingAPI.Services;
using PackingAPI.Data;

namespace PackingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly PackingService _service;
    private readonly AppDbContext _context;

    public PedidosController(PackingService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpPost]
    public IActionResult ProcessarPedidos([FromBody] List<Pedido> pedidos)
    {
        foreach (var pedido in pedidos)
        {

            var caixas = _service.EmpacotarProdutos(pedido.Produtos);
            pedido.CaixasUsadas = caixas;
            _context.Pedidos.Add(pedido);
        }

        _context.SaveChanges();

        return Ok(pedidos);
    }