using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;
using Tienda.Infrastructure.Persistence;

namespace Tienda.Infrastructure.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly ExamenContext _db;
        public InventarioRepository(ExamenContext db)
        {
            _db = db;
        }

        public async Task Agregar(Domain.Entities.Inventario inventario)
        {
            var i = new Persistence.Inventario()
            {
                IdSucursal = inventario.IdSucursal,
                IdProducto = inventario.IdProducto,
                Cantidad = inventario.Cantidad
            };
            await _db.Inventarios.AddAsync(i);
            await _db.SaveChangesAsync();
        }

        public async Task Editar(Domain.Entities.Inventario inventario)
        {
            var i = await _db.Inventarios.FirstOrDefaultAsync(i => i.IdInventario == inventario.IdInventario);

            if (i != null)
            {
                i.IdProducto = inventario.IdProducto;
                i.IdSucursal = inventario.IdSucursal;
                i.Cantidad = inventario.Cantidad;

                await _db.SaveChangesAsync();
            }
        }

        public Task<Domain.Entities.Inventario> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Inventario> ObtenerPorId(int idProducto, int idSucursal)
        {
            var data = await _db.Inventarios.Where(x => x.IdProducto == idProducto && x.IdSucursal == idSucursal).FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }
            Domain.Entities.Inventario inv = new Domain.Entities.Inventario(data.IdProducto, data.IdSucursal, data.Cantidad);
            inv.IdInventario = data.IdInventario;
            return inv;
        }

        public Task<List<Domain.Entities.Inventario>> ObtenerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
