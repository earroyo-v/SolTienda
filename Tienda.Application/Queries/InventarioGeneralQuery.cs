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
    public record InventarioGeneralQuery : IRequest<List<ConsultarInventarioDTO>>;
    public class InventarioGeneralQueryHandler : IRequestHandler<InventarioGeneralQuery, List<ConsultarInventarioDTO>>
    {
        private readonly IConsultarInventarioRepository _repository;
        public InventarioGeneralQueryHandler(IConsultarInventarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ConsultarInventarioDTO>> Handle(InventarioGeneralQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerTodo();
        }
    }
}
