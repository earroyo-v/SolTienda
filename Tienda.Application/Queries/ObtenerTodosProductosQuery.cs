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
    public record ObtenerTodosProductosQuery : IRequest<List<Producto>>;

    public class ObtenerTodosProductosQueryHandler : IRequestHandler<ObtenerTodosProductosQuery, List<Producto>>
    {
        private readonly IProductoRepository _Repository;
        public ObtenerTodosProductosQueryHandler(IProductoRepository Repository)
        {
            _Repository = Repository;
        }
        public async Task<List<Producto>> Handle(ObtenerTodosProductosQuery request, CancellationToken cancellationToken)
        {
            return await _Repository.ObtenerTodosAsync();
        }
    }
}
