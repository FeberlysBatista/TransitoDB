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
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<Empleado> GetByDocumentoAsync(string documento)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Documento == documento);
        }

        public async Task<IEnumerable<Empleado>> GetByCargoAsync(int cargoId)
        {
            return await _context.Empleados
                .Where(e => e.CargoId == cargoId)
                .ToListAsync();
        }
    }
}