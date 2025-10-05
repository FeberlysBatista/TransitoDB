using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IUnidadRepository : IGenericRepository<Unidad>
    {
        Task<IEnumerable<Unidad>> GetByProvinciaAsync(string provincia);
    }
}