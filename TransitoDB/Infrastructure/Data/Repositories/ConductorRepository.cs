using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoApp.Infrastructure.Data.Repositories
{
    public class ConductorRepository : GenericRepository<Conductor>, IConductorRepository
    {
        public ConductorRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<Conductor> GetByLicenciaAsync(string licenciaNro)
        {
            return await _context.Conductores.FirstOrDefaultAsync(c => c.LicenciaNro == licenciaNro);
        }

        public async Task<Conductor> GetByCedulaAsync(string cedula)
        {
            return await _context.Conductores.FirstOrDefaultAsync(c => c.Cedula == cedula);
        }
    }
}