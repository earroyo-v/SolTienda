using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Application.DTO.Interfaces
{
    public interface IHistorialVentasRepository
    {
        Task<List<HistorialVentasDTO>> ObtenerTodo();
    }
}
