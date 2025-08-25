using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Application.DTO
{
    public class HistorialVentasDTO
    {
        public int IdVenta { get; set; }
        public string Sucursal { get; set; } = string.Empty;
        public DateTime FechaVenta { get; set; }
        public int ProductosVendidos { get; set; }
        public decimal Total { get; set; }
    }
}
