using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.Common.Dto.ProductosXPEdido
{
    public class ProductosXPedidoDto
    {
        public int Id { get; set; }
        public int Id_Pedido { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public int ValorPorCantidad { get; set; }
    }
}
