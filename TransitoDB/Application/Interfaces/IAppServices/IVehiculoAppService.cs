using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IVehiculoAppService
    {
        Task<IEnumerable<VehiculoDto>> GetAllAsync();
        Task<VehiculoDto> GetByIdAsync(int id);
        Task<VehiculoDto> GetByPlacaAsync(string placa);
        Task<VehiculoDto> GetByVINAsync(string vin);
        Task<VehiculoDto> AddAsync(VehiculoDto vehiculoDto);
        Task UpdateAsync(VehiculoDto vehiculoDto);
        Task DeleteAsync(int id);
    }
}