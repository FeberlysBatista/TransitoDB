using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface ITipoInfraccionService
    {
        Task<IEnumerable<TipoInfraccion>> GetAllAsync();
        Task<TipoInfraccion> GetByIdAsync(int id);
        Task<TipoInfraccion> GetByCodigoAsync(string codigo);
        Task<TipoInfraccion> AddAsync(TipoInfraccion tipoInfraccion);
        Task UpdateAsync(TipoInfraccion tipoInfraccion);
        Task DeleteAsync(int id);
    }
}