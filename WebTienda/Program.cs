using Microsoft.EntityFrameworkCore;
using Tienda.Application.DTO.Interfaces;
using Tienda.Application.Queries;
using Tienda.Domain.Interfaces;
using Tienda.Infrastructure.Persistence;
using Tienda.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ObtenerTodoSucursalQuery).Assembly));

builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IConsultarInventarioRepository, ConsultarInventarioRepository>();
builder.Services.AddScoped<IHistorialVentasRepository, HistorialVentasRepository>();

builder.Services.AddDbContext<ExamenContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
