using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Entities
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; private set; }
        public string Direccion { get; private set; }
        public bool EsSedePrincipal { get; private set; }

        public Sucursal(string nombre, string direccion, bool esSedePrincipal)
        {
            if (string.IsNullOrWhiteSpace(nombre)) { throw new ArgumentNullException("El nombre esta vacio"); }
            if (string.IsNullOrWhiteSpace(direccion)) { throw new ArgumentNullException("La direccion no puede estar vacia"); }

            Nombre = nombre;
            Direccion = direccion;
            EsSedePrincipal = esSedePrincipal;
        }
    }
}
