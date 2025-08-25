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
    public class SucursalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SucursalController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarSucursalCommand sucursal)
        {
            var item = await _mediator.Send(sucursal);
            return CreatedAtAction(nameof(Agregar), new { id = item.IdSucursal }, item);
        }
        [HttpGet]
        public async Task<List<Sucursal>> GetAll()
        {
            return await _mediator.Send(new ObtenerTodoSucursalQuery());
        }
    }
}
