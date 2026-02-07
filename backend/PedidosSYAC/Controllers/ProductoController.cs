using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Services.Interfaces;
using PedidosSYAC.Services.Services.Interfaces;
using PedidosSYAC.Common.Dto.Autors;
using PedidosSYAC.Common.Dto.Productos;

namespace PedidosSYAC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IMapper _mapper;
        private readonly int maxProductos = 5;
        private IClientes _cliente;
        private IProductos _producto;
        public ProductoController
            (
                ILogger<ProductoController> logger
                ,IMapper mapper
                ,IClientes cliente
                ,IProductos producto
            )
        {
            _logger = logger;
            _mapper = mapper;
            _cliente = cliente;
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
        [Route("GetProductoById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductoDto>> GetProductoById(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var result = await _producto.GetById(Id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [Route("AddProducto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductoDto>> AddProducto([FromBody] ProductoCreacionDto producto)
        {
            var getListProductos = await _producto.Get();
            if (getListProductos.Count() == maxProductos)
            {
                ModelState.AddModelError("LimiteProductos", "No es posible registrar sel libro, se alcanzó el máximo permitido");
                return BadRequest(ModelState);
            }
            if (getListProductos.Where(b => b.NombreProducto.ToLower() == producto.valorUnitario.ToLower()).FirstOrDefault() != null)
            {
                ModelState.AddModelError("LibroExiste", "El libro ya existe");
                return BadRequest(ModelState);
            }
            try
            {
                ClientesDto cliente =await _cliente.GetById(producto.Id_Cliente);
                if (cliente == null)
                {
                    ModelState.AddModelError("AutorNoValido", "El autor no existe");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
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

            var findProducto = await _producto.GetById(producto.Id);
            if (findProducto == null)
                return NotFound();

            if (await _cliente.GetById(findProducto.Id) == null) { 
                ModelState.AddModelError("ProductoNoValido","El Producto no existe");
                return BadRequest();
            }
            await _producto.UpdateProducto(producto);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteProducto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProducto(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var producto = await _producto.GetById(Id);
            if (producto == null)
                return NotFound();

            _producto.DeleteProducto(producto);

            return NoContent();
        }
    }
}
