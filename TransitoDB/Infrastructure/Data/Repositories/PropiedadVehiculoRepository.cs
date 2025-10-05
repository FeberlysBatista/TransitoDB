using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoDB.Infrastructure.Data.Repositories
{
    public class PropiedadVehiculoRepository : GenericRepository<PropiedadVehiculo>, IPropiedadVehiculoRepository
    {
        public PropiedadVehiculoRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PropiedadVehiculo>> GetByVehiculoIdAsync(int vehiculoId)
        {
            return await _context.PropiedadVehiculos
                .Where(pv => pv.VehiculoId == vehiculoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PropiedadVehiculo>> GetByConductorIdAsync(int conductorId)
        {
            return await _context.PropiedadVehiculos
                .Where(pv => pv.ConductorId == conductorId)
                .ToListAsync();
        }

        public async Task<PropiedadVehiculo> GetVigenteByVehiculoIdAsync(int vehiculoId, DateTime fecha)
        {
            return await _context.PropiedadVehiculos
                .Where(pv => pv.VehiculoId == vehiculoId)
                .Where(pv => pv.Desde <= fecha && (pv.Hasta == null || pv.Hasta >= fecha))
                .FirstOrDefaultAsync();
        }
    }
}