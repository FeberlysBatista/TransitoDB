using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IPropiedadVehiculoAppService
    {
        Task<IEnumerable<PropiedadVehiculoDto>> GetAllAsync();
        Task<PropiedadVehiculoDto> GetByIdAsync(int vehiculoId, int conductorId, DateTime desde);
        Task<IEnumerable<PropiedadVehiculoDto>> GetByVehiculoIdAsync(int vehiculoId);
        Task<IEnumerable<PropiedadVehiculoDto>> GetByConductorIdAsync(int conductorId);
        Task<PropiedadVehiculoDto> GetVigenteByVehiculoIdAsync(int vehiculoId, DateTime fecha);
        Task<PropiedadVehiculoDto> AddAsync(PropiedadVehiculoDto propiedadVehiculoDto);
        Task UpdateAsync(PropiedadVehiculoDto propiedadVehiculoDto);
        Task DeleteAsync(int vehiculoId, int conductorId, DateTime desde);
    }
}