using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Common.Dto.Productos;

namespace PedidosSYAC.Services.Interfaces
{
    public interface IProductos
    {
        Task<List<ProductoDto>> Get();
        Task<ProductoDto> GetByName(string nombreProducto);
        Task UpdateProducto(ProductoActualizacionDto produto);
        Task<ProductoDto> AddProducto(ProductoCreacionDto produto);
        void DeleteProducto(ProductoDto produto);

    }
}
