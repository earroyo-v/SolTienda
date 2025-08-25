using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Commands
{
    public record EditarProductoCommand(int idProducto, string Nombre, string Descripcion, decimal Precio) : IRequest<Producto>;
    public class EditarProductoCommandHandler : IRequestHandler<EditarProductoCommand, Producto>
    {
        private readonly IProductoRepository _Repository;
        public EditarProductoCommandHandler(IProductoRepository repository)
        {
            _Repository = repository;
        }
        public async Task<Producto> Handle(EditarProductoCommand request, CancellationToken cancellationToken)
        {
            var p = new Producto()
            {
                IdProducto = request.idProducto,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Precio = request.Precio
            };
            if (p == null)
            {
                return null;
            }
            await _Repository.Editar(p);
            return p;
        }
    }
}
