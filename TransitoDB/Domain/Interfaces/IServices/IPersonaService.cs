using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona> GetByIdAsync(int id);
        Task<Persona> GetByCedulaAsync(string cedula);
        Task<Persona> AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(int id);
    }
}