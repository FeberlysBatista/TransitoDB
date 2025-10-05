using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IEmpleadoRepository : IGenericRepository<Empleado>
    {
        Task<Empleado> GetByDocumentoAsync(string documento);
        Task<IEnumerable<Empleado>> GetByCargoAsync(int cargoId);
    }
}