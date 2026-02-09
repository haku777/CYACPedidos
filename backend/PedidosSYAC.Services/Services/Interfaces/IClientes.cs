using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Common.Dto;
using PedidosSYAC.Common.Dto.Clientes;

namespace PedidosSYAC.Services.Services.Interfaces
{
    public interface IClientes
    {
        Task<List<ClientesDto>> Get();
        Task<ClientesDto> GetById(int Id);
        Task UpdateCliente(ClientesActualizarDto Cliente);
        Task<ClientesDto> AddCliente(ClientesCreacionDto Cliente);
        Task<int> DeleteClienteAsync(int identification);
    }

}
