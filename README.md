# SolTienda

Sistema de gestión de productos, compras y ventas para sucursales. Diseñado con Clean Architecture, CQRS y enfoque en claridad, mantenibilidad y experiencia del desarrollador.

---

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (local o remoto)
- [Postman](https://www.postman.com/downloads/) (opcional, para probar endpoints)
- Visual Studio 2022

---

## Estructura del proyecto

- `Tienda.API`: Proyecto principal con controladores y configuración
- `Tienda.Application`: Lógica de negocio con comandos y queries
- `Tienda.Domain`: Entidades y reglas del dominio
- `Tienda.Infrastructure`: Configuración de EF Core y DbContext

---

## Base de datos

1. Ejecuta el script `SolTienda_DB.sql` ubicado en la carpeta `setup\Scripts` para crear la base de datos y sus tablas relacionadas.

Base de datos: `EXAMEN`

La base de datos `EXAMEN` contiene las siguientes tablas:

| Tabla           | Descripción                                 |
|-----------------|---------------------------------------------|
| `Compra`        | Registro de compras realizadas en sede      |
| `DetalleCompra` | Detalles de cada producto comprado          |
| `Sucursal`      | Información de sucursales                   |
| `Inventario`    | Cantidad de productos por sucursal          |
| `Producto`      | Catálogo de productos                       |
| `Venta`         | Registro de ventas por sucursal             |
| `DetalleVenta`  | Detalles de cada producto vendido           |

Cada tabla está relacionada mediante claves foráneas para mantener la integridad referencial. El script `SolTienda_DB.sql` crea esta estructura y puede ejecutarse en SQL Server para levantar la base localmente.

2. Verifica que la cadena de conexión en `appsettings.json` apunte correctamente a tu instancia de SQL Server:

```json
"ConnectionStrings": {
  "sql": "Server=.; Database=EXAMEN; Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true"
}

--

## Endpoints principales

| Método | Ruta                                               | Descripción                          |
|--------|----------------------------------------------------|--------------------------------------|
| GET    | http://localhost:5048/api/Inventario/General       | Consultar inventario general         |
| POST   | http://localhost:5048/api/Compra                   | Registrar compra en sede             |
| POST   | http://localhost:5048/api/Venta                    | Registrar venta en sucursal          |
| GET    | http://localhost:5048/api/Producto                 | Consultar productos                  |
| POST   | http://localhost:5048/api/Producto                 | Crear nuevo producto                 |
| PUT    | http://localhost:5048/api/Producto /{id}           | Actualizar producto existente        |
| GET    | http://localhost:5048/api/Venta                    | Consultar historial de ventas        |
| GET    | http://localhost:5048/api/Inventario/Sucursal      | Inventario por sucursal              |





