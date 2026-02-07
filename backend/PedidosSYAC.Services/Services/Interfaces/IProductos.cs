using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Common.Dto.Productos;

namespace PedidosSYAC.Services.Interfaces
{
    public interface IProductos
    {
        Task<List<ProductoDto>> Get();
        Task<ProductoDto> GetById(int Id);
        Task UpdateProducto(ProductoActualizacionDto produto);
        Task<ProductoDto> AddProducto(ProductoCreacionDto produto);
        void DeleteProducto(ProductoDto produto);

    }
}
