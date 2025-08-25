using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Domain.Interfaces
{
    public interface IInventarioRepository
    {
        Task<Inventario> ObtenerPorId(int id);
        Task<Inventario> ObtenerPorId(int idProducto, int idSucursal);
        Task<List<Inventario>> ObtenerTodo();
        Task Agregar(Inventario inventario);
        Task Editar(Inventario inventario);
    }
}
