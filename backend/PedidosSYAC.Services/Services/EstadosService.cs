using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PedidosSYAC.Common.Dto.Estados;
using PedidosSYAC.DataAccess;
using PedidosSYAC.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.Services.Services
{
    public class EstadosService : IEstados
    {
        private readonly PedidosContext _context;
        private readonly IMapper _mapper;
        public EstadosService(PedidosContext context, IMapper mapper) { _context = context; _mapper = mapper; }

        public async Task<List<EstadosDto>> Get()
        {
            var estados = await _context.Estados.ToListAsync();
            List<EstadosDto> listaEstados = _mapper.Map<List<EstadosDto>>(estados);
            return listaEstados;
        }

        public async Task<List<EstadosSoloNombreDto>> GetAllByDto()
        {
            //ProjectTo hace que AutoMapper modifique la consulta SQL para traer solo las columnas necesarias
            return await _context.Estados.ProjectTo<EstadosSoloNombreDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
