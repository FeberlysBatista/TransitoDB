using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IMultaDetalleService
    {
        Task<IEnumerable<MultaDetalle>> GetAllAsync();
        Task<MultaDetalle> GetByIdAsync(long id);
        Task<IEnumerable<MultaDetalle>> GetByMultaIdAsync(long multaId);
        Task<MultaDetalle> AddAsync(MultaDetalle multaDetalle);
        Task UpdateAsync(MultaDetalle multaDetalle);
        Task DeleteAsync(long id);
    }
}