using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; private set; }
        public int IdSucursal { get; private set; }
        public int Cantidad { get; private set; }
        public Inventario(int productoId, int sucursalId, int cantidadInicial)
        {
            if (cantidadInicial < 0)
                throw new ArgumentException("La cantidad inicial no puede ser negativa.");

            IdProducto = productoId;
            IdSucursal = sucursalId;
            Cantidad = cantidadInicial;
        }

        public void AgregarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a agregar debe ser mayor a cero.");

            Cantidad += cantidad;
        }

        public void DescontarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a descontar debe ser mayor a cero.");

            if (cantidad > Cantidad)
                throw new InvalidOperationException("No hay suficiente stock para descontar.");

            Cantidad -= cantidad;
        }

    }
}
