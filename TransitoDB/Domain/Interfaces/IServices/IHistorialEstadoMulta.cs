using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IHistorialEstadoMultaService
    {
        Task<IEnumerable<HistorialEstadoMulta>> GetAllAsync();
        Task<HistorialEstadoMulta> GetByIdAsync(long id);
        Task<IEnumerable<HistorialEstadoMulta>> GetByMultaIdAsync(long multaId);
        Task<HistorialEstadoMulta> AddAsync(HistorialEstadoMulta historialEstadoMulta);
        Task UpdateAsync(HistorialEstadoMulta historialEstadoMulta);
        Task DeleteAsync(long id);
    }
}