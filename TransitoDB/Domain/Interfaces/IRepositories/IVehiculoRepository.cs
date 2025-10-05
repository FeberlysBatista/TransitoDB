using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IVehiculoRepository : IGenericRepository<Vehiculo>
    {
        Task<Vehiculo> GetByPlacaAsync(string placa);
        Task<Vehiculo> GetByVINAsync(string vin);
    }
}