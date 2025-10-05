using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IEmpleadoAppService
    {
        Task<IEnumerable<EmpleadoDto>> GetAllAsync();
        Task<EmpleadoDto> GetByIdAsync(int id);
        Task<EmpleadoDto> GetByDocumentoAsync(string documento);
        Task<IEnumerable<EmpleadoDto>> GetByCargoAsync(int cargoId);
        Task<EmpleadoDto> AddAsync(EmpleadoDto empleadoDto);
        Task UpdateAsync(EmpleadoDto empleadoDto);
        Task DeleteAsync(int id);
    }
}