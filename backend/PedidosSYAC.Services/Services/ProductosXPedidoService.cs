using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidosSYAC.Common.Dto.ProductosXPEdido;
using PedidosSYAC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.Services.Services
{
    public class ProductosXPedidoService
    {
        private readonly PedidosContext _context;
        private readonly IMapper _mapper;
        public ProductosXPedidoService(PedidosContext context, IMapper mapper) { _context = context; _mapper = mapper; }


        public async Task<List<ProductosXPedidoDto>> GetByPedido(int pedido) {
            var productosXPedido = await _context.ProductosXPedido.Where(x=>x.Pedido.Id == pedido).ToListAsync();
            return _mapper.Map<List<ProductosXPedidoDto>>(productosXPedido);
        }


    }
}
