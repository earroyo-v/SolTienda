using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public List<DetalleCompra> Detalles = new();
        public Compra(int sucursalId)
        {
            IdSucursal = sucursalId;
            FechaCompra = DateTime.UtcNow;
            //Total = total;
        }

        public void AgregarDetalle(int productoId, int cantidad, decimal precioUnitario)
        {
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (precioUnitario <= 0) throw new ArgumentException("El precio unitario debe ser mayor a cero.");

            var detalle = new DetalleCompra(productoId, cantidad, precioUnitario);
            Detalles.Add(detalle);
            Total += cantidad * precioUnitario;
        }

        //public decimal CalcularTotal() => _detalles.Sum(d => d.Subtotal);
    }
}
