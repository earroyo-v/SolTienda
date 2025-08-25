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
    public class AgregarCompraCommandHandlerTest
    {
        [Fact]
        public async Task AgregarCompra_DeberiaCrearCompraYActualizarInventario()
        {
            // Arrange
            var producto = new Producto() { IdProducto=1,Nombre="Sabritas",Precio=20};
            var inventario = new Inventario(1, 1, 5);
            var compraGenerada = new Compra(1);
            compraGenerada.IdCompra = 99;

            var productoRepoMock = new Mock<IProductoRepository>();
            productoRepoMock.Setup(r => r.ObtenerPorId(1)).ReturnsAsync(producto);

            var inventarioRepoMock = new Mock<IInventarioRepository>();
            inventarioRepoMock.Setup(r => r.ObtenerPorId(1, 1)).ReturnsAsync(inventario);
            inventarioRepoMock.Setup(r => r.Editar(It.IsAny<Inventario>())).Returns(Task.CompletedTask);

            var compraRepoMock = new Mock<ICompraRepository>();
            compraRepoMock.Setup(r => r.Agregar(It.IsAny<Compra>())).ReturnsAsync(99);

            var handler = new AgregarCompraCommandHandler(compraRepoMock.Object, inventarioRepoMock.Object, productoRepoMock.Object);

            var command = new AgregarCompraCommand(
                idSucursal: 1,
                detalles: new List<AgregarCompraDetalle>
                {
            new AgregarCompraDetalle(productoId: 1, cantidad: 3)
                });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(99, result.IdCompra);
            Assert.Single(result.Detalles);
            Assert.Equal(1, result.Detalles[0].IdProducto);
            Assert.Equal(3, result.Detalles[0].Cantidad);
        }

    }
}
