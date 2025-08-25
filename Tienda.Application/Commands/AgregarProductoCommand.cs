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
    public record AgregarProductoCommand(string Nombre, string Descripcion, decimal Precio) : IRequest<Producto>;
    public class AgregarProductoCommandHandler : IRequestHandler<AgregarProductoCommand, Producto>
    {
        private readonly IProductoRepository _Repository;
        public AgregarProductoCommandHandler(IProductoRepository repository)
        {
            _Repository = repository;
        }
        public async Task<Producto> Handle(AgregarProductoCommand request, CancellationToken cancellationToken)
        {
            var p = new Producto()
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Precio = request.Precio
            };
            await _Repository.Agregar(p);
            return p;
        }
    }
}
