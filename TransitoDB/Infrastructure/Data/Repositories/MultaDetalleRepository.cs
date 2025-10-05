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
    public class MultaDetalleRepository : GenericRepository<MultaDetalle>, IMultaDetalleRepository
    {
        public MultaDetalleRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MultaDetalle>> GetByMultaIdAsync(long multaId)
        {
            return await _context.MultaDetalles
                .Where(md => md.MultaId == multaId)
                .Include(md => md.TipoInfraccion)
                .ToListAsync();
        }
    }
}