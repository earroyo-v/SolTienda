using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Application.Commands;
using Tienda.Application.DTO;
using Tienda.Application.Queries;

namespace Tienda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VentaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarVentaCommand venta)
        {
            var item = await _mediator.Send(venta);
            return CreatedAtAction(nameof(Agregar), new { id = item.IdVenta }, item);
        }
        [HttpGet]
        public async Task<ActionResult<List<HistorialVentasDTO>>> Historial()
        {
            return await _mediator.Send(new HistorialVentasQuery());
        }
    }
}
