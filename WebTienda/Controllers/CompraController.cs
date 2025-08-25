using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Application.Commands;
using Tienda.Application.Queries;

namespace Tienda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompraController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarCompraCommand compra)
        {
            var item = await _mediator.Send(compra);
            return CreatedAtAction(nameof(Agregar), new { id = item.IdCompra }, item);
        }
    }
}
