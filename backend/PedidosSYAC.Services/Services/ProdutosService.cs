using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidosSYAC.Common.Dto.Productos;
using PedidosSYAC.DataAccess;
using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Services.Interfaces;

namespace PedidosSYAC.Services.Services
{
    public class ProdutosService : IProductos
    {
        private PedidosContext _context;
        public IMapper _mapper;
        public ProdutosService(PedidosContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public  async Task<List<ProductoDto>> Get()
        {
            var books =  await _context.Productos.ToListAsync();
            List<ProductoDto> booksList = new List<ProductoDto>();
            foreach (var book in books) {
                var bookItem = _mapper.Map<ProductoDto>(book);
                booksList.Add(bookItem);
            }

            return booksList;
        }


        public async Task<ProductoDto> GetById(int Id)
        {
            var book = await _context.Productos.FirstOrDefaultAsync(b => b.Id == Id);
            ProductoDto mapBook = _mapper.Map<ProductoDto>(book);
            return mapBook;
        }

        public async Task<ProductoDto> AddProducto(ProductoCreacionDto book)
        {

            Productos newBook = _mapper.Map<Productos>(book);
            var result = await _context.Productos.AddAsync(newBook);
            await _context.SaveChangesAsync();
            ProductoDto newBookAdded = await GetById(result.Entity.Id);
            return newBookAdded;
        }

        public async Task UpdateProducto(ProductoActualizacionDto producto)
        {
            var existsProducto = _context.Productos.FirstOrDefault(b => b.Id == producto.Id);
            if (existsProducto != null)
            {
                existsProducto.Nombre = producto.Nombre;
                existsProducto.Cantidad = producto.Cantidad;
                existsProducto.ValorUnitario = producto.ValorUnitario;
                
                await _context.SaveChangesAsync();
            }
        }

        public void DeleteProducto(ProductoDto book) {
            var findBook = _context.Productos.FirstOrDefault(a => a.Id == book.Id);
            if (findBook != null)
            {
                _context.Productos.Remove(findBook);
                _context.SaveChanges();
            }
        }

    }
}
