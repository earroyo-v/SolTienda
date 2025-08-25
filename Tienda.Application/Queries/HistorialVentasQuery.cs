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
    public record HistorialVentasQuery : IRequest<List<HistorialVentasDTO>>;
    public class HistorialVentasQueryHandler : IRequestHandler<HistorialVentasQuery, List<HistorialVentasDTO>>
    {
        private readonly IHistorialVentasRepository _repository;
        public HistorialVentasQueryHandler(IHistorialVentasRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<HistorialVentasDTO>> Handle(HistorialVentasQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerTodo();
        }
    }
}
