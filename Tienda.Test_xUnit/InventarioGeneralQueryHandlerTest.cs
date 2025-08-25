using Moq;
using Tienda.Application.DTO;
using Tienda.Application.DTO.Interfaces;
using Tienda.Application.Queries;
using Tienda.Domain.Entities;

namespace Tienda.Test_xUnit
{
    public class InventarioGeneralQueryHandlerTest
    {
        [Fact]
        public async Task InventarioGeneral_DeberiaRetornarListaDeDTOs()
        {

            // Arrange
            var inventarioMock = new List<ConsultarInventarioDTO>
            {
                new ConsultarInventarioDTO { idSucursal = 1, Sucursal="Norte",Producto = "Papas", Cantidad = 5 ,PrecioUnitario=20},
                new ConsultarInventarioDTO { idSucursal = 2, Sucursal="Sur",Producto = "Refresco", Cantidad = 3 ,PrecioUnitario=20}
            };

            var repoMock = new Mock<IConsultarInventarioRepository>();
            repoMock.Setup(r => r.ObtenerTodo()).ReturnsAsync(inventarioMock);

            var handler = new InventarioGeneralQueryHandler(repoMock.Object);
            var query = new InventarioGeneralQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.Producto == "Papas");
        }
    }
}