using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Common.Dto.Autors;
using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Services.Services.Interfaces;

namespace PedidosSYAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientes _cliente;
        public ClienteController(IClientes cliente) { 
            _cliente = cliente;
        }

        [HttpGet]
        [Route("GetClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClientesDto>>> GetClientes() {

            return await _cliente.Get();
        }

        [HttpGet]
        [Route("GetClienteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientesDto>> GetClienteById(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var result = await _cliente.GetById(Id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        [Route("AddCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientesDto>> AddCliente([FromBody] ClientesCreacionDto cliente)
        {

            if (cliente == null)
                return BadRequest();

            var result = await _cliente.AddCliente(cliente);

            if (result == null)
                return BadRequest();

            return result;
        }


        [HttpPut]
        [Route("UpdateCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAutor([FromBody] ClientesActualizarDto cliente)
        {

            if (cliente == null)
                return NotFound();

            var result = await _cliente.GetById(cliente.Id);

            if (result == null)
                return BadRequest();

            await _cliente.UpdateCliente(cliente);

            return NoContent();
        }


        [HttpDelete]
        [Route("DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCliente(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var cliente = await _cliente.GetById(Id);
            if (cliente == null)
                return NotFound();

            await _cliente.DeleteCliente(cliente);

            return NoContent();
        }
    }
}
