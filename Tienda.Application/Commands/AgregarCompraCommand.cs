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
    public record AgregarCompraCommand(int idSucursal, List<AgregarCompraDetalle> detalles) : IRequest<Compra>;
    public record AgregarCompraDetalle(int productoId, int cantidad);

    public class AgregarCompraCommandHandler : IRequestHandler<AgregarCompraCommand, Compra>
    {
        private readonly ICompraRepository _CompraRepository;
        private readonly IInventarioRepository _InventarioRepository;
        private readonly IProductoRepository _ProductoRepository;
        public AgregarCompraCommandHandler(ICompraRepository repo, IInventarioRepository inventarioRepository, IProductoRepository productoRepository)
        {
            _CompraRepository = repo;
            _InventarioRepository = inventarioRepository;
            _ProductoRepository = productoRepository;
        }
        public async Task<Compra> Handle(AgregarCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = new Compra(request.idSucursal);

            foreach (var detalle in request.detalles)
            {
                var prod = await _ProductoRepository.ObtenerPorId(detalle.productoId);
                if (prod == null)
                    throw new Exception($"Producto {detalle.productoId} no encontrado.");
                compra.AgregarDetalle(detalle.productoId, detalle.cantidad, prod.Precio);

                var inventario = await _InventarioRepository.ObtenerPorId(detalle.productoId, request.idSucursal);

                if (inventario == null)
                {
                    inventario = new Inventario(detalle.productoId, request.idSucursal, detalle.cantidad);
                    await _InventarioRepository.Agregar(inventario);
                }
                else
                {
                    inventario.AgregarStock(detalle.cantidad);
                    await _InventarioRepository.Editar(inventario);
                }
            }

            await _CompraRepository.Agregar(compra);
            return compra;
        }
    }
}
