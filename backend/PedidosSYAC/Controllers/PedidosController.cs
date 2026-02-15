using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Common.Dto.Pedidos;
using PedidosSYAC.Services.Services.Interfaces;

namespace PedidosSYAC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidos _pedidos;
        public PedidosController(IPedidos pedidos) { _pedidos = pedidos; }

        [HttpGet]
        [Route("GetPedidos")]
        public async Task<List<PedidosDto>> GetPedidos()
        {
            var pedidos = await _pedidos.Get();
            return pedidos;
        }

        [HttpPost]
        [Route("AddPedido")]
        public async Task<PedidosDto> AddPedido([FromBody] PedidosCreacionDto PedidoDto) {
            //validar pedido
            var pedidoValido = await _pedidos.AddPedido(PedidoDto);
            return pedidoValido;
        }
    }
}
