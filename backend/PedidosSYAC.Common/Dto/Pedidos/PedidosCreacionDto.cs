using PedidosSYAC.Common.Dto.Clientes;
using PedidosSYAC.Common.Dto.Estados;
using PedidosSYAC.Common.Dto.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.Common.Dto.Pedidos
{
    public class PedidosCreacionDto
    {
        public virtual List<ProductoDto> Productos { get; set; }
        public virtual EstadosDto Estado { get; set; }
        public int ValorTotal { get; set; }
    }
}
