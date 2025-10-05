using System;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IPropiedadVehiculoRepository : IGenericRepository<PropiedadVehiculo>
    {
        Task<IEnumerable<PropiedadVehiculo>> GetByVehiculoIdAsync(int vehiculoId);
        Task<IEnumerable<PropiedadVehiculo>> GetByConductorIdAsync(int conductorId);
        Task<PropiedadVehiculo> GetVigenteByVehiculoIdAsync(int vehiculoId, DateTime fecha);
    }
}