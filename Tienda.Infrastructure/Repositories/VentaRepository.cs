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
    public class VentaRepository : IVentaRepository
    {
        private readonly ExamenContext _db;
        public VentaRepository(ExamenContext db)
        {
            _db = db;
        }
        public async Task<int> Agregar(Venta venta)
        {
            var v = new Ventum
            {
                IdSucursal = venta.IdSucursal,
                FechaVenta = venta.FechaVenta,
                Total = venta.Total,
                DetalleVenta = venta.Detalles.Select(d => new DetalleVentum
                {
                    IdProducto = d.IdProducto,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList()
            };

            await _db.Venta.AddAsync(v);
            await _db.SaveChangesAsync();

            return v.IdVenta;
        }

        public async Task Editar(Venta venta)
        {
            var v = await _db.Venta.FirstOrDefaultAsync(x => x.IdVenta == venta.IdVenta);

            if (v != null)
            {
                v.FechaVenta = venta.FechaVenta;
                v.IdSucursal = venta.IdSucursal;
                v.Total = venta.Total;

                await _db.SaveChangesAsync();
            }
        }

        public Task<Venta> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Venta>> ObtenerTodo()
        {
            List<Venta> ls = new List<Venta>();
            var data = await _db.Venta.ToListAsync();
            foreach (var item in data)
            {
                var v = new Venta(item.IdSucursal);
                v.IdVenta = item.IdVenta;
                ls.Add(v);
            }
            return ls;
        }
    }
}
