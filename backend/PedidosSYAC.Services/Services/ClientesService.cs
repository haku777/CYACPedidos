using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidosSYAC.Common.Dto.Clientes;
using PedidosSYAC.DataAccess;
using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Services.Services.Interfaces;

namespace PedidosSYAC.Services.Services
{
    public class ClientesService : IClientes
    {
        private readonly PedidosContext _context;
        private readonly IMapper _mapper;
        public ClientesService(PedidosContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<ClientesDto>> Get()
        {
            var clientes = await _context.Clientes.ToListAsync();
            
            List<ClientesDto> listClientes = new List<ClientesDto>();

            foreach (Clientes cliente in clientes) {
                   ClientesDto clienteItem = _mapper.Map<ClientesDto>(cliente);

                listClientes.Add(clienteItem);
            }

            return listClientes;
        }


        public async Task<ClientesDto> GetById(int Id)
        {
            var autor = await _context.Clientes.FirstOrDefaultAsync(a=>a.Id == Id);
            ClientesDto mapAutor = _mapper.Map<ClientesDto>(autor);
            return mapAutor;
        }

        public async Task<ClientesDto> AddCliente(ClientesCreacionDto cliente)
        {
            var nuevoCliente = _mapper.Map<Clientes>(cliente);
            var result = await _context.Clientes.AddAsync(nuevoCliente);
            await _context.SaveChangesAsync();
            ClientesDto newBookAdded = await GetById(result.Entity.Id);
            return newBookAdded;
        }
  
        public async Task UpdateCliente(ClientesActualizarDto cliente)
        {
            var xd = _context.Clientes.FirstOrDefault(a=>a.Id == cliente.Id);
            if (xd != null) {
                xd.Nombre= cliente.Nombre;
                xd.Direccion= cliente.Direccion;
        await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteCliente(ClientesDto cliente) 
        {
            var findAutor = _context.Clientes.FirstOrDefault(a=>a.Id == cliente.Id);
            if(findAutor != null)
            {
                _context.Clientes.Remove(findAutor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
