using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoDB.Infrastructure.Data.Repositories
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<Vehiculo> GetByPlacaAsync(string placa)
        {
            return await _context.Vehiculos.FirstOrDefaultAsync(v => v.Placa == placa);
        }

        public async Task<Vehiculo> GetByVINAsync(string vin)
        {
            return await _context.Vehiculos.FirstOrDefaultAsync(v => v.VIN == vin);
        }
    }
}