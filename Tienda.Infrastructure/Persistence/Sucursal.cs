using System;
using System.Collections.Generic;

namespace Tienda.Infrastructure.Persistence;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool EsSedePrincipal { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
