using PedidosSYAC.Common.Dto.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSYAC.Services.Services.Interfaces
{
    public interface IEstados
    {
        Task<List<EstadosDto>> Get();
    }
}
