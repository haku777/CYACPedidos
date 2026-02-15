using AutoMapper;
using PedidosSYAC.DataAccess.Entity;
using PedidosSYAC.Common.Dto.Clientes;
using PedidosSYAC.Common.Dto.Productos;
using PedidosSYAC.Common.Dto.Estados;
using PedidosSYAC.Common.Dto.Pedidos;

namespace PedidosSYAC.Services.AutoMapper
{
    public class BasicMapper : Profile
    {

        public BasicMapper() {

            CreateMap<Clientes, ClientesDto>().ReverseMap();
            //ejemplo de solo data necesaria
            CreateMap<Clientes, ClientesDataDto>().ReverseMap();
            CreateMap<Clientes, ClientesActualizarDto>().ReverseMap();
            CreateMap<Clientes, ClientesCreacionDto>().ReverseMap();

            CreateMap<Productos, ProductoDto>();
            CreateMap<ProductoDto, Productos>();
            CreateMap<Productos, ProductoActualizacionDto>().ReverseMap();
            CreateMap<Productos, ProductoCreacionDto>().ReverseMap();
           
            CreateMap<Estados, EstadosDto>().ReverseMap();
            CreateMap<Estados, EstadosSoloNombreDto>().ReverseMap();

            CreateMap<Pedidos, PedidosDto>().ReverseMap();


            //CreateMap<Clientes, ClientesDto>()
            //.ForMember(dest => dest.Nombre,
            //   opt => opt.MapFrom(src => $"{src.Nombre} {src.Direccion}"));
        }
    }
}
