using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IConductorRepository : IGenericRepository<Conductor>
    {
        Task<Conductor> GetByLicenciaAsync(string licenciaNro);
        Task<Conductor> GetByCedulaAsync(string cedula);
    }
}