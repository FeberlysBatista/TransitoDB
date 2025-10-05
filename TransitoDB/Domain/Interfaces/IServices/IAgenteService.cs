using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IAgenteService
    {
        Task<IEnumerable<Agente>> GetAllAsync();
        Task<Agente> GetByIdAsync(int id);
        Task<Agente> GetByMatriculaAsync(string matricula);
        Task<IEnumerable<Agente>> GetByUnidadAsync(int unidadId);
        Task<Agente> GetByEmpleadoIdAsync(int empleadoId);
        Task<Agente> AddAsync(Agente agente);
        Task UpdateAsync(Agente agente);
        Task DeleteAsync(int id);
    }
}