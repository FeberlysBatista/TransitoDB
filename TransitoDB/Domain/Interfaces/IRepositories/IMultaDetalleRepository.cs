using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IMultaDetalleRepository : IGenericRepository<MultaDetalle>
    {
        Task<IEnumerable<MultaDetalle>> GetByMultaIdAsync(long multaId);
    }
}