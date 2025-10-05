using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IAgenteAppService
    {
        Task<IEnumerable<AgenteDto>> GetAllAsync();
        Task<AgenteDto> GetByIdAsync(int id);
        Task<AgenteDto> GetByMatriculaAsync(string matricula);
        Task<IEnumerable<AgenteDto>> GetByUnidadAsync(int unidadId);
        Task<AgenteDto> GetByEmpleadoIdAsync(int empleadoId);
        Task<AgenteDto> AddAsync(AgenteDto agenteDto);
        Task UpdateAsync(AgenteDto agenteDto);
        Task DeleteAsync(int id);
    }
}