using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Application.Commands;
using Tienda.Application.Queries;
using Tienda.Domain.Entities;

namespace Tienda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await _mediator.Send(new ObtenerTodosProductosQuery());
        }
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] AgregarProductoCommand producto)
        {
            var item = await _mediator.Send(producto);
            return CreatedAtAction(nameof(Agregar), new { id = item.IdProducto }, item);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] EditarProductoCommand producto)
        {
            if (id != producto.idProducto)
            {
                return BadRequest();
            }
            var item = await _mediator.Send(producto);
            if (item == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
