using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Queries
{
    public record ObtenerTodoSucursalQuery : IRequest<List<Sucursal>>;

    public class ObtenerTodoSucursalQueryHandler : IRequestHandler<ObtenerTodoSucursalQuery, List<Sucursal>>
    {
        private readonly ISucursalRepository _sucursalRepository;
        public ObtenerTodoSucursalQueryHandler(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }
        public async Task<List<Sucursal>> Handle(ObtenerTodoSucursalQuery request, CancellationToken cancellationToken)
        {
            var sucursales = await _sucursalRepository.ObtenerTodo();

            return sucursales;
        }
    }
}
