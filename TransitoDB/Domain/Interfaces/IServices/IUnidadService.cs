using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IUnidadService
    {
        Task<IEnumerable<Unidad>> GetAllAsync();
        Task<Unidad> GetByIdAsync(int id);
        Task<IEnumerable<Unidad>> GetByProvinciaAsync(string provincia);
        Task<Unidad> AddAsync(Unidad unidad);
        Task UpdateAsync(Unidad unidad);
        Task DeleteAsync(int id);
    }
}