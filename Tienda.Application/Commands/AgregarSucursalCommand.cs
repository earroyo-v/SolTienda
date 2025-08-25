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
    public record AgregarSucursalCommand(string nombre, string direccion, bool sede) : IRequest<Sucursal>;

    public class AgregarSucursalCommandHandler : IRequestHandler<AgregarSucursalCommand, Sucursal>
    {
        private readonly ISucursalRepository _sucursalRepository;
        public AgregarSucursalCommandHandler(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }
        public async Task<Sucursal> Handle(AgregarSucursalCommand request, CancellationToken cancellationToken)
        {
            var sucursal = new Sucursal(request.nombre, request.direccion, request.sede);

            await _sucursalRepository.Agregar(sucursal);

            return sucursal;
        }
    }
}
