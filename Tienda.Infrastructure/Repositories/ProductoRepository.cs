using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Interfaces;
using Tienda.Infrastructure.Persistence;

namespace Tienda.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ExamenContext _db;
        public ProductoRepository(ExamenContext db)
        {
            _db = db;
        }

        public async Task<List<Domain.Entities.Producto>> ObtenerTodosAsync()
        {
            List<Domain.Entities.Producto> ls = new List<Domain.Entities.Producto>();
            var data = await _db.Productos.ToListAsync();
            foreach (var item in data)
            {
                Domain.Entities.Producto p = new Domain.Entities.Producto()
                {
                    IdProducto = item.IdProducto,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Descripcion = item.Descripcion
                };
                ls.Add(p);
            }
            return ls;
        }
        public async Task<int> Agregar(Domain.Entities.Producto producto)
        {
            var p = new Persistence.Producto()
            {
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio
            };
            await _db.Productos.AddAsync(p);
            await _db.SaveChangesAsync();

            return p.IdProducto;
        }
        public async Task Editar(Domain.Entities.Producto producto)
        {
            var p = await _db.Productos.FirstOrDefaultAsync(p => p.IdProducto == producto.IdProducto);

            if (p != null)
            {
                p.Nombre = producto.Nombre;
                p.Descripcion = producto.Descripcion;
                p.Precio = producto.Precio;

                await _db.SaveChangesAsync();
            }
        }

        public async Task<Domain.Entities.Producto> ObtenerPorId(int id)
        {
            var item = await _db.Productos.Where(x => x.IdProducto == id).FirstOrDefaultAsync();
            if (item == null)
            {
                return null;
            }
            Domain.Entities.Producto p = new Domain.Entities.Producto()
            {
                IdProducto = item.IdProducto,
                Nombre = item.Nombre,
                Precio = item.Precio,
                Descripcion = item.Descripcion
            };
            return p;
        }
    }
}
