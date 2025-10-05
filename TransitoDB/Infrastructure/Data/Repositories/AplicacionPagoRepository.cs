using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Infrastructure.Data.Repositories;

namespace TransitoApp.Infrastructure.Data.Repositories
{
    public class AplicacionPagoRepository : GenericRepository<AplicacionPago>, IAplicacionPagoRepository
    {
        public AplicacionPagoRepository(TransitoDbContext context) : base(context)
        {
        }

        public async Task<decimal> GetTotalAplicadoByMultaDetalleIdAsync(long multaDetalleId)
        {
            var total = await _context.AplicacionPagos
                .Where(ap => ap.MultaDetalleId == multaDetalleId)
                .SumAsync(ap => ap.MontoAplicado);

            return total;
        }
    }
}