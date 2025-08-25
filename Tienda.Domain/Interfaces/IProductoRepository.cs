using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> ObtenerPorId(int id);
        Task<List<Producto>> ObtenerTodosAsync();
        Task<int> Agregar(Producto producto);
        Task Editar(Producto producto);
    }
}
