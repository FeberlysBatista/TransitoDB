using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoDB.Infrastructure.Data.Repositories
{
    public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
    {
        public CargoRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<Cargo> GetByNombreAsync(string nombre)
        {
            return await _context.Cargos.FirstOrDefaultAsync(c => c.Nombre == nombre);
        }
    }
}