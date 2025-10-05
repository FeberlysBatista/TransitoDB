using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoApp.Infrastructure.Data.Repositories
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<Persona> GetByCedulaAsync(string cedula)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.Cedula == cedula);
        }
    }
}