using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Services.Services.Interfaces;

namespace PedidosSYAC.test
{
    public class ProductoSYACTest
    {
        private readonly IClientes _cliente;
        public ProductoSYACTest(IClientes cliente) { _cliente = cliente; }

        [Fact]
        public void ValidacionProductos()
        {
            // Arrange (Preparar)
            
            // Act (Actuar)

            var result = _cliente.Get();
            // Assert (Afirmar)
            
        }
    }
}