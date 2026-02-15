using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.DataAccess.Entity
{
    public class ProductosXPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Id_Pedido")]
        public Pedidos Pedido { get; set; }
        [ForeignKey("Id_Producto")]
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
        public int ValorPorCantidad { get; set; }
    }
}
