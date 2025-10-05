using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoApp.Infrastructure.Data.Repositories
{
    public class HistorialEstadoMultaRepository : GenericRepository<HistorialEstadoMulta>, IHistorialEstadoMultaRepository
    {
        public HistorialEstadoMultaRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<HistorialEstadoMulta>> GetByMultaIdAsync(long multaId)
        {
            return await _context.HistorialEstadoMultas
                .Where(h => h.MultaId == multaId)
                .OrderByDescending(h => h.Fecha)
                .ToListAsync();
        }
    }
}