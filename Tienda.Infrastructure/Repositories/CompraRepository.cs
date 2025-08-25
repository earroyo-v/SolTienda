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
    public class CompraRepository : ICompraRepository
    {
        private readonly ExamenContext _db;
        public CompraRepository(ExamenContext db)
        {
            _db = db;
        }
        public async Task<int> Agregar(Domain.Entities.Compra compra)
        {
            var c = new Persistence.Compra
            {
                IdSucursal = compra.IdSucursal,
                FechaCompra = compra.FechaCompra,
                Total = compra.Total,
                DetalleCompras = compra.Detalles.Select(d => new Persistence.DetalleCompra
                {
                    IdProducto = d.IdProducto,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList()
            };

            await _db.Compras.AddAsync(c);
            await _db.SaveChangesAsync();

            return c.IdCompra;
        }

        public async Task Editar(Domain.Entities.Compra compra)
        {
            var c = await _db.Compras.FirstOrDefaultAsync(c => c.IdCompra == compra.IdCompra);

            if (c != null)
            {
                c.FechaCompra = compra.FechaCompra;
                c.IdSucursal = compra.IdSucursal;
                c.Total = compra.Total;

                await _db.SaveChangesAsync();
            }
        }

        public Task<Domain.Entities.Compra> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Entities.Compra>> ObtenerTodo()
        {
            List<Domain.Entities.Compra> ls = new List<Domain.Entities.Compra>();
            var data = await _db.Compras.ToListAsync();
            foreach (var item in data)
            {
                Domain.Entities.Compra p = new Domain.Entities.Compra(item.IdSucursal);
                p.IdCompra = item.IdCompra;
                ls.Add(p);
            }
            return ls;
        }
    }
}
