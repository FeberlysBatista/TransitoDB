using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoApp.Infrastructure.Data.Repositories
{
    public class TipoInfraccionRepository : GenericRepository<TipoInfraccion>, ITipoInfraccionRepository
    {
        public TipoInfraccionRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<TipoInfraccion> GetByCodigoAsync(string codigo)
        {
            return await _context.TipoInfracciones.FirstOrDefaultAsync(ti => ti.Codigo == codigo);
        }
    }
}