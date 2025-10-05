using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IConductorService
    {
        Task<IEnumerable<Conductor>> GetAllAsync();
        Task<Conductor> GetByIdAsync(int id);
        Task<Conductor> GetByLicenciaAsync(string licenciaNro);
        Task<Conductor> GetByCedulaAsync(string cedula);
        Task<Conductor> AddAsync(Conductor conductor);
        Task UpdateAsync(Conductor conductor);
        Task DeleteAsync(int id);
    }
}