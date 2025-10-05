using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IPropiedadVehiculoService
    {
        Task<IEnumerable<PropiedadVehiculo>> GetAllAsync();
        Task<PropiedadVehiculo> GetByIdAsync(int vehiculoId, int conductorId, DateTime desde);
        Task<IEnumerable<PropiedadVehiculo>> GetByVehiculoIdAsync(int vehiculoId);
        Task<IEnumerable<PropiedadVehiculo>> GetByConductorIdAsync(int conductorId);
        Task<PropiedadVehiculo> GetVigenteByVehiculoIdAsync(int vehiculoId, DateTime fecha);
        Task<PropiedadVehiculo> AddAsync(PropiedadVehiculo propiedadVehiculo);
        Task UpdateAsync(PropiedadVehiculo propiedadVehiculo);
        Task DeleteAsync(int vehiculoId, int conductorId, DateTime desde);
    }
}