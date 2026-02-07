using AutoMapper;
using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Common.Dto.Autors;
using PedidosSYAC.Common.Dto.Productos;

namespace PedidosSYAC.Services.AutoMapper
{
    public class BasicMapper : Profile
    {

        public BasicMapper() {

            CreateMap<Clientes, ClientesDto>().ReverseMap();
            CreateMap<Clientes, ClientesActualizarDto>().ReverseMap();
            CreateMap<Clientes, ClientesCreacionDto>().ReverseMap();

            CreateMap<Productos, ProductoDto>();
            CreateMap<ProductoDto, Productos>();
            CreateMap<Productos, ProductoActualizacionDto>().ReverseMap();
            CreateMap<Productos, ProductoCreacionDto>().ReverseMap();
           
        }
    }
}
