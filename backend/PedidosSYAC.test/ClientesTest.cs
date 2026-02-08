using Moq;
using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Controllers;
using PedidosSYAC.Services.Services;
using PedidosSYAC.Common.Dto.Clientes;

namespace PedidosSYAC.test
{
    public class ClientesTest
    {
        private readonly ClientesController _controller;
        private readonly Mock<ClientesService> _serviceMock;

        ClientesTest() {
            // 1. "Mockeamos" la interfaz del servicio
            _serviceMock = new Mock<ClientesService>();

            // 2. Inyectamos el mock en el controlador
            _controller = new ClientesController(_serviceMock.Object);

        }


        [Fact]
        public async Task GetClientesTest()
        {
            // ARRANGE (Preparar)
            var clientesFake = new List<ClientesDto>
                            {
                                new ClientesDto { Id = 1, Nombre = "Jimmy" },
                                new ClientesDto { Id = 2, Nombre = "Jorge" }
                            };

            _serviceMock.Setup(s => s.Get()).ReturnsAsync(clientesFake);

            // ACT (Ejecutar)
            var result = await _controller.GetClientes();

            // ASSERT (Verificar)
            var actionResult = Assert.IsType<ActionResult<List<ClientesDto>>>(result);
            var okResult = Assert.IsType<List<ClientesDto>>(actionResult.Value);

            Assert.Equal(2, okResult.Count);
            Assert.Equal("Jimmy", okResult[0].Nombre);
        }

    }
}
