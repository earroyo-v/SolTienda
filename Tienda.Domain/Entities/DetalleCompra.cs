using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;

        public DetalleCompra(int productoId, int cantidad, decimal precioUnitario)
        {
            IdProducto = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

    }
}
