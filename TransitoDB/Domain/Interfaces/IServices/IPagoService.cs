using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IPagoService
    {
        Task<IEnumerable<Pago>> GetAllAsync();
        Task<Pago> GetByIdAsync(long id);
        Task<IEnumerable<Pago>> GetByMultaIdAsync(long multaId);
        Task<Pago> AddAsync(Pago pago);
        Task UpdateAsync(Pago pago);
        Task DeleteAsync(long id);
    }
}