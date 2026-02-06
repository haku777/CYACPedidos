using Microsoft.AspNetCore.Mvc;
using PedidosSYAC.Common.Dto;
using PedidosSYAC.Common.Dto.Autors;

namespace PedidosSYAC.Services.Services.Interfaces
{
    public interface IClientes
    {
        Task<List<ClientesDto>> Get();
        Task<ClientesDto> GetById(int Id);
        Task UpdateCliente(ClientesActualizarDto Cliente);
        Task<ClientesDto> AddCliente(ClientesCreacionDto Cliente);
        Task DeleteCliente(ClientesDto Cliente);
    }

}
