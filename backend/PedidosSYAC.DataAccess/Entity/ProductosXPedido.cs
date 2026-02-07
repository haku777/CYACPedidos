using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.DataAccess.Entity
{
    public class ProductosXPedido
    {
        public int Id { get; set; }
        [ForeignKey("Id_Pedido")]
        public Pedidos Id_Pedido { get; set; }
        [ForeignKey("Id_Producto")]
        public Productos Id_Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
