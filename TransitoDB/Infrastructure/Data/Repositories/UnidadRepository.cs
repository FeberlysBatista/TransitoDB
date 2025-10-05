using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoApp.Infrastructure.Data.Repositories
{
    public class UnidadRepository : GenericRepository<Unidad>, IUnidadRepository
    {
        public UnidadRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Unidad>> GetByProvinciaAsync(string provincia)
        {
            return await _context.Unidades
                .Where(u => u.Provincia == provincia)
                .ToListAsync();
        }
    }
}