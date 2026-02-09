using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Services.Interfaces;
using PedidosSYAC.Services.Services.Interfaces;
using PedidosSYAC.Common.Dto.Clientes;
using PedidosSYAC.Common.Dto.Productos;

namespace PedidosSYAC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly IMapper _mapper;
        private IProductos _producto;
        public ProductosController
            (
                ILogger<ProductosController> logger
                ,IMapper mapper
                ,IProductos producto
            )
        {
            _logger = logger;
            _mapper = mapper;
            _producto = producto;
        }


        [HttpGet]
        [Route("GetProductos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            _logger.LogInformation("Obtener los Productos");
            var result = await _producto.Get();
            return Ok(result);
        }


        [HttpGet]
        [Route("GetProductoByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductoDto>> GetProductoByname(string nombreProducto)
        {
            if (string.IsNullOrEmpty(nombreProducto))
                return BadRequest();

            var result = await _producto.GetByName(nombreProducto);

            if (result == null)
                return NotFound(new {message ="Pedido no encontrado"});

            return Ok(result);
        }


        [HttpPost]
        [Route("AddProducto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductoDto>> AddProducto([FromBody] ProductoCreacionDto producto)
        {
            var getListProductos = await _producto.Get();

            if (getListProductos.Where(b => b.Nombre.ToLower() == producto.Nombre.ToLower()).FirstOrDefault() != null)
            {
                ModelState.AddModelError("ProductoExiste", "El Producto ya existe");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (producto == null)
                return BadRequest(producto);

            var newBook = await _producto.AddProducto(producto);
            return newBook;
        }


        [HttpPut]
        [Route("UpdateProducto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProducto([FromBody] ProductoActualizacionDto producto)
        {
            if (producto == null)
                return BadRequest();

            var findProducto = await _producto.GetByName(producto.Nombre);
            if (findProducto == null) { 
                ModelState.AddModelError("ProductoNoValido","El Producto no existe");
                return BadRequest(ModelState);
            }

            await _producto.UpdateProducto(producto);
            return Ok(new { message = "Producto actualizado!"});
        }

        [HttpDelete]
        [Route("DeleteProducto/{nombreProducto}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProducto(string nombreProducto)
        {
            if (string.IsNullOrEmpty(nombreProducto))
                return BadRequest();

            var producto = await _producto.GetByName(nombreProducto);
            if (producto == null)
                return NotFound();

            _producto.DeleteProducto(producto);

            return NoContent();
        }
    }
}
