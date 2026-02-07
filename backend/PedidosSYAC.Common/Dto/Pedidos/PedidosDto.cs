using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.Common.Dto.Pedidos
{
    public class PedidosDto
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Producto { get; set; }
        public int Id_Estado { get; set; }
        public int ValorTotal { get; set; }
    }
}
