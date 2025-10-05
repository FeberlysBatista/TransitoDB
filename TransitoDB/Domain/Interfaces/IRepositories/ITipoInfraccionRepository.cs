using System.Threading.Tasks;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Domain.Entities;


namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface ITipoInfraccionRepository : IGenericRepository<TipoInfraccion>
    {
        Task<TipoInfraccion> GetByCodigoAsync(string codigo);
    }
}