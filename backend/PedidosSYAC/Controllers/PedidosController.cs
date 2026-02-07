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
        public Task<List<PedidosDto>> GetPedidos()
        {
            var pedidos = _pedidos.Get();
            return pedidos;
        }
    }
}
