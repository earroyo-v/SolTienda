--Consulta de inventario general --
CREATE PROCEDURE spConsultarInventario
@idSucursal INT = NULL
AS
BEGIN
select S.idSucursal, S.nombre as Sucursal, P.nombre as Producto, I.cantidad as Cantidad, P.precio as PrecioUnitario
from Sucursal as S
Inner Join Inventario as I on S.idSucursal = I.idSucursal
Inner Join Producto as P on P.idProducto = I.idProducto
WHERE (@idSucursal IS NULL OR S.idSucursal = @idSucursal)
ORDER BY S.nombre, P.nombre
END

--Consultar historial de ventas --
CREATE PROCEDURE spConsultarVentas
AS
BEGIN
SELECT 
    V.idVenta,
    S.nombre AS Sucursal,
    V.fechaVenta,
    SUM(D.cantidad) AS ProductosVendidos,
	V.total as Total
FROM Venta V
INNER JOIN Sucursal S ON V.idSucursal = S.idSucursal
INNER JOIN DetalleVenta D ON V.idVenta = D.idVenta
GROUP BY V.idVenta, S.nombre, V.fechaVenta, V.total
ORDER BY V.fechaVenta DESC
END