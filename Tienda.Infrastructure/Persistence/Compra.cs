using System;
using System.Collections.Generic;

namespace Tienda.Infrastructure.Persistence;

public partial class Compra
{
    public int IdCompra { get; set; }

    public DateTime FechaCompra { get; set; }

    public decimal Total { get; set; }

    public int IdSucursal { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
