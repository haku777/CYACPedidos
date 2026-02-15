using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidosSYAC.Common.Dto.Estados;
using PedidosSYAC.Common.Dto.Pedidos;
using PedidosSYAC.DataAccess;
using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public async Task<List<PedidosDto>> Get() 
        { 
            //var pedidos = await _context.Pedidos.ToListAsync();
            var pedidos = await _context.Pedidos.ProjectTo<PedidosDto>(_mapper.ConfigurationProvider).ToListAsync();
            List<PedidosDto> listaPedidos = _mapper.Map<List<PedidosDto>>(pedidos);
            return listaPedidos;
        }

        public async Task<PedidosDto> AddPedido(PedidosCreacionDto PedidoCreacion) 
        {
            var hayProductos = PedidoCreacion.Productos.Select(p => p.Id).ToList();
            //var hayProductos = _context.Productos.Where(x => x.Cantidad <= PedidoCreacion.Producto);
            
            var productosDb = await _context.Productos.Where(p => hayProductos.Contains(p.Id)).ToListAsync();

            var sinStock = PedidoCreacion.Productos.Where(p =>
                productosDb.Any(db => db.Id == p.Id && db.Cantidad < p.Cantidad)
            ).ToList();



            if (sinStock.Any())
            {
                throw new Exception("Algunos productos no tienen stock suficiente.");
            }
            var falta = new PedidosDto();
            return falta;

            //validar stock de productos, actualizar productos tambien stock
            //pedido
            //    cliente identification? o id?
            //    estado = 1
            //    valorTotal = porCada producto x valor unitario y cantidad validar etc

        //add ProductosXPedido



        //al agregar un pedido modificamos tanto pedido como productos por pedido estado = 1
        //validamos si existe stock
        // validamos el precio al multiplicar la cantidad x valor unitario
        //el valor en productos x pedido sera cantidad por valor unitario x cada producto agregado en un foreach?
        //insercion a pedido y productosXpedido
        }








    }
}
