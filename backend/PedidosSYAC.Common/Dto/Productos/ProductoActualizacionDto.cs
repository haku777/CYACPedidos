using System.ComponentModel.DataAnnotations;


namespace PedidosSYAC.Common.Dto.Productos
{
    public class ProductoActualizacionDto
    {
        [Required]
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnitario { get; set; }
    }
}
