using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosSYAC.DataAccess.Entity
{
    public class Pedidos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        [ForeignKey("Id_Cliente")]
        public virtual Clientes Cliente { get; set; }
        public int Id_Producto { get; set; }
        [ForeignKey("Id_Producto")]
        public virtual Productos Producto { get; set; }
        public int Id_Estado { get; set; }
        [ForeignKey("Id_Estado")]
        public virtual Estados Estado { get; set; }

        public int ValorTotal { get; set; }

    }
}
