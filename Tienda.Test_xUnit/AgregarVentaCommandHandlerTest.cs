using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Application.Commands;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Test_xUnit
{
    public class AgregarVentaCommandHandlerTest
    {
        [Fact]
        public async Task AgregarVenta_DeberiaReducirStockYCrearVenta()
        {
            // Arrange
            var producto = new Producto() { IdProducto = 1, Nombre = "Sabritas", Precio = 20 };
            var inventario = new Inventario(1, 1, 10); // 10 unidades en sucursal 1
            var ventaGenerada = new Venta(1);
            ventaGenerada.IdVenta = 77;

            var productoRepoMock = new Mock<IProductoRepository>();
            productoRepoMock.Setup(r => r.ObtenerPorId(1)).ReturnsAsync(producto);

            var inventarioRepoMock = new Mock<IInventarioRepository>();
            inventarioRepoMock.Setup(r => r.ObtenerPorId(1, 1)).ReturnsAsync(inventario);
            inventarioRepoMock.Setup(r => r.Editar(It.IsAny<Inventario>())).Returns(Task.CompletedTask);

            var ventaRepoMock = new Mock<IVentaRepository>();
            ventaRepoMock.Setup(r => r.Agregar(It.IsAny<Venta>())).ReturnsAsync(77);

            var handler = new AgregarVentaCommandHandler(ventaRepoMock.Object, inventarioRepoMock.Object, productoRepoMock.Object);

            var command = new AgregarVentaCommand(
                idSucursal: 1,
                detalles: new List<AgregarVentaDetalle>
                {
            new AgregarVentaDetalle(productoId: 1, cantidad: 2)
                });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(77, result.IdVenta);
            Assert.Single(result.Detalles);
            Assert.Equal(1, result.Detalles[0].IdProducto);
            Assert.Equal(2, result.Detalles[0].Cantidad);
            Assert.Equal(8, inventario.Cantidad); // Stock reducido
        }

    }
}
