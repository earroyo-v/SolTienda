using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Application.DTO.Interfaces
{
    public interface IConsultarInventarioRepository
    {
        Task<List<ConsultarInventarioDTO>> ObtenerTodo();
        Task<List<ConsultarInventarioDTO>> ObtenerSucursal(int id);
    }
}
