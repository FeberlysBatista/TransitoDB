using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IAgenteRepository : IGenericRepository<Agente>
    {
        Task<Agente> GetByMatriculaAsync(string matricula);
        Task<IEnumerable<Agente>> GetByUnidadAsync(int unidadId);
        Task<Agente> GetByEmpleadoIdAsync(int empleadoId);
    }
}