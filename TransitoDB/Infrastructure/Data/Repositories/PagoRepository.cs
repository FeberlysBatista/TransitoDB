using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoDB.Infrastructure.Data.Repositories
{
    public class PagoRepository : GenericRepository<Pago>, IPagoRepository
    {
        public PagoRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pago>> GetByMultaIdAsync(long multaId)
        {
            return await _context.Pagos
                .Where(p => p.MultaId == multaId)
                .OrderByDescending(p => p.Fecha)
                .ToListAsync();
        }
    }
}