using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;
using Tienda.Infrastructure.Persistence;

namespace Tienda.Infrastructure.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly ExamenContext _db;
        public SucursalRepository(ExamenContext db)
        {
            _db = db;
        }

        public async Task<int> Agregar(Domain.Entities.Sucursal sucursal)
        {
            var s = new Persistence.Sucursal()
            {
                Nombre = sucursal.Nombre,
                Direccion = sucursal.Direccion,
                EsSedePrincipal = sucursal.EsSedePrincipal
            };
            await _db.Sucursals.AddAsync(s);
            await _db.SaveChangesAsync();

            return s.IdSucursal;
        }

        public Task Editar(Domain.Entities.Sucursal sucursal)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Sucursal> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Entities.Sucursal>> ObtenerTodo()
        {
            var sucursalesInfra = await _db.Sucursals.ToListAsync();

            var sucursalesDominio = sucursalesInfra.Select(s => new Domain.Entities.Sucursal(s.Nombre, s.Direccion, s.EsSedePrincipal)
            {
                IdSucursal = s.IdSucursal,
            }).ToList();

            return sucursalesDominio;
        }
    }
}
