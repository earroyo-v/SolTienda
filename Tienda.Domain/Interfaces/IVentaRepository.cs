using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Domain.Interfaces
{
    public interface IVentaRepository
    {
        Task<Venta> ObtenerPorId(int id);
        Task<List<Venta>> ObtenerTodo();
        Task Agregar(Venta venta);
        Task Editar(Venta venta);
    }
}
