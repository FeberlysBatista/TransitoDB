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
    public class AgenteRepository : GenericRepository<Agente>, IAgenteRepository
    {
        public AgenteRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<Agente> GetByMatriculaAsync(string matricula)
        {
            return await _context.Agentes.FirstOrDefaultAsync(a => a.Matricula == matricula);
        }

        public async Task<IEnumerable<Agente>> GetByUnidadAsync(int unidadId)
        {
            return await _context.Agentes
                .Where(a => a.UnidadId == unidadId)
                .ToListAsync();
        }

        public async Task<Agente> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _context.Agentes.FirstOrDefaultAsync(a => a.EmpleadoId == empleadoId);
        }
    }
}