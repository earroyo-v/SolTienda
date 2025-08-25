using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; private set; }
        public int IdProducto { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }

        public DetalleVenta(int idProducto, int cantidad, decimal precioUnitario)
        {
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

    }
}
