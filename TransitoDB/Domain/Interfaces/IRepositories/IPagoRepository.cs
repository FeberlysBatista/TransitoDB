using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IPagoRepository : IGenericRepository<Pago>
    {
        Task<IEnumerable<Pago>> GetByMultaIdAsync(long multaId);
    }
}