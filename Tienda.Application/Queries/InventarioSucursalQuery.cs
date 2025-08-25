using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Application.DTO;
using Tienda.Application.DTO.Interfaces;

namespace Tienda.Application.Queries
{
    public record InventarioSucursalQuery(int idSucursal) : IRequest<List<ConsultarInventarioDTO>>;
    public class InventarioSucursalQueryHandler : IRequestHandler<InventarioSucursalQuery, List<ConsultarInventarioDTO>>
    {
        private readonly IConsultarInventarioRepository _repository;
        public InventarioSucursalQueryHandler(IConsultarInventarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ConsultarInventarioDTO>> Handle(InventarioSucursalQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerSucursal(request.idSucursal);
        }
    }
}
