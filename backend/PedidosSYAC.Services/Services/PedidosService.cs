using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidosSYAC.Common.Dto.Pedidos;
using PedidosSYAC.DataAccess;
using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.Services.Services
{
    public class PedidosService : IPedidos
    {
        private readonly PedidosContext _context;
        private readonly IMapper _mapper;
        public PedidosService(PedidosContext context, IMapper mapper) { _context = context;_mapper = mapper; }

        public async Task<List<PedidosDto>> Get() { 
            var pedidos = await _context.Pedidos.ToListAsync();
            List<PedidosDto> listaPedidos = _mapper.Map<List<PedidosDto>>(pedidos);
            return listaPedidos;
        }

    }
}
