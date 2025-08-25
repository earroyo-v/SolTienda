using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Domain.Interfaces
{
    public interface ISucursalRepository
    {
        Task<Sucursal> ObtenerPorId(int id);
        Task<List<Sucursal>> ObtenerTodo();
        Task Agregar(Sucursal sucursal);
        Task Editar(Sucursal sucursal);
    }
}
