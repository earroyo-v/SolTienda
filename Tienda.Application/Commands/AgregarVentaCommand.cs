using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Commands
{
    public record AgregarVentaCommand(int idSucursal, List<AgregarVentaDetalle> detalles) : IRequest<Venta>;
    public record AgregarVentaDetalle(int productoId, int cantidad);
    public class AgregarVentaCommandHandler : IRequestHandler<AgregarVentaCommand, Venta>
    {
        private readonly IVentaRepository _VentaRepository;
        private readonly IInventarioRepository _InventarioRepository;
        private readonly IProductoRepository _ProductoRepository;
        public AgregarVentaCommandHandler(IVentaRepository repo, IInventarioRepository inventarioRepository, IProductoRepository productoRepository)
        {
            _VentaRepository = repo;
            _InventarioRepository = inventarioRepository;
            _ProductoRepository = productoRepository;
        }
        public async Task<Venta> Handle(AgregarVentaCommand request, CancellationToken cancellationToken)
        {
            var venta = new Venta(request.idSucursal);

            foreach (var detalle in request.detalles)
            {
                var prod = await _ProductoRepository.ObtenerPorId(detalle.productoId);
                if (prod == null)
                    throw new Exception($"Producto {detalle.productoId} no encontrado.");
                venta.AgregarDetalle(detalle.productoId, detalle.cantidad, prod.Precio);

                var inventario = await _InventarioRepository.ObtenerPorId(detalle.productoId, request.idSucursal);

                if (inventario != null)
                {
                    inventario.DescontarStock(detalle.cantidad);
                    await _InventarioRepository.Editar(inventario);
                }
                else
                {
                    throw new Exception($"Producto {detalle.productoId} no encontrado.");

                }
            }

            await _VentaRepository.Agregar(venta);
            return venta;
        }
    }
}
