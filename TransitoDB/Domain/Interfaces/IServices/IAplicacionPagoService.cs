using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IAplicacionPagoService
    {
        Task<IEnumerable<AplicacionPago>> GetAllAsync();
        Task<AplicacionPago> GetByIdAsync(long id);
        Task<decimal> GetTotalAplicadoByMultaDetalleIdAsync(long multaDetalleId);
        Task<AplicacionPago> AddAsync(AplicacionPago aplicacionPago);
        Task UpdateAsync(AplicacionPago aplicacionPago);
        Task DeleteAsync(long id);
    }
}