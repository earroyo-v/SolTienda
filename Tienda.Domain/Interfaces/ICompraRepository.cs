using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;

namespace Tienda.Domain.Interfaces
{
    public interface ICompraRepository
    {
        Task<Compra> ObtenerPorId(int id);
        Task<List<Compra>> ObtenerTodo();
        Task Agregar(Compra compra);
        Task Editar(Compra compra);
    }
}
