using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public int IdSucursal { get; set; }
        public List<DetalleVenta> Detalles { get; private set; } = new();

        public Venta(int sucursalId)
        {
            if (sucursalId == 0)
                throw new ArgumentException("Sucursal inválida");

            IdSucursal = sucursalId;
            FechaVenta = DateTime.UtcNow;
        }

        public void AgregarDetalle(int productoId, int cantidad, decimal precioUnitario)
        {
            if (cantidad <= 0) throw new ArgumentException("Cantidad inválida");
            if (precioUnitario <= 0) throw new ArgumentException("Precio inválido");

            var detalle = new DetalleVenta(productoId, cantidad, precioUnitario);
            Detalles.Add(detalle);
            Total += cantidad * precioUnitario;
        }
    }
}
