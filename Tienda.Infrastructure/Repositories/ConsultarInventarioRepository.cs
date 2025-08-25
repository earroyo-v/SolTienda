using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Application.DTO;
using Tienda.Application.DTO.Interfaces;
using Tienda.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Infrastructure.Repositories
{
    public class ConsultarInventarioRepository : IConsultarInventarioRepository
    {
        private readonly ExamenContext _db;
        public ConsultarInventarioRepository(ExamenContext db)
        {
            _db = db;
        }
        public async Task<List<ConsultarInventarioDTO>> ObtenerSucursal(int id)
        {
            return await _db.Set<ConsultarInventarioDTO>().FromSqlInterpolated($"EXEC spConsultarInventario @idSucursal = {id}")
                .ToListAsync();
        }

        public async Task<List<ConsultarInventarioDTO>> ObtenerTodo()
        {
            return await _db.Set<ConsultarInventarioDTO>().FromSqlInterpolated($"EXEC spConsultarInventario")
                .ToListAsync();
        }
    }
}
