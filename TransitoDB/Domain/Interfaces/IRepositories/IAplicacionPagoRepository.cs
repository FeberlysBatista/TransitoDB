using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IAplicacionPagoRepository : IGenericRepository<AplicacionPago>
    {
        Task<decimal> GetTotalAplicadoByMultaDetalleIdAsync(long multaDetalleId);
    }
}