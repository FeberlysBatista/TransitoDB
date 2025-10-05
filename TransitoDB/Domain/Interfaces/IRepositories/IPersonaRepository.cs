using System.Threading.Tasks;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<Persona> GetByCedulaAsync(string cedula);
    }
}