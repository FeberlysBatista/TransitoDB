using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IHistorialEstadoMultaRepository : IGenericRepository<HistorialEstadoMulta>
    {
        Task<IEnumerable<HistorialEstadoMulta>> GetByMultaIdAsync(long multaId);
    }
}