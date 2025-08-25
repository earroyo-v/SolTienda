using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Application.DTO;
using Tienda.Application.Queries;

namespace Tienda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("General")]
        public async Task<ActionResult<List<ConsultarInventarioDTO>>> General()
        {
            return await _mediator.Send(new InventarioGeneralQuery());
        }
        [HttpGet("Sucursal/{id}")]
        public async Task<ActionResult<List<ConsultarInventarioDTO>>> Sucursal(int id)
        {
            var query = new InventarioSucursalQuery(id);
            return await _mediator.Send(query);
        }
    }
}
