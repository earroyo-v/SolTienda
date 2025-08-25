using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Application.DTO;
using Tienda.Application.DTO.Interfaces;
using Tienda.Infrastructure.Persistence;

namespace Tienda.Infrastructure.Repositories
{
    public class HistorialVentasRepository : IHistorialVentasRepository
    {
        private readonly ExamenContext _db;
        public HistorialVentasRepository(ExamenContext db)
        {
            _db = db;
        }
        public async Task<List<HistorialVentasDTO>> ObtenerTodo()
        {
            return await _db.Set<HistorialVentasDTO>().FromSqlInterpolated($"EXEC spConsultarVentas")
                .ToListAsync();
        }
    }
}
