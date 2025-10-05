using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IConductorAppService
    {
        Task<IEnumerable<ConductorDto>> GetAllAsync();
        Task<ConductorDto> GetByIdAsync(int id);
        Task<ConductorDto> GetByLicenciaAsync(string licenciaNro);
        Task<ConductorDto> GetByCedulaAsync(string cedula);
        Task<ConductorDto> AddAsync(ConductorDto conductorDto);
        Task UpdateAsync(ConductorDto conductorDto);
        Task DeleteAsync(int id);
    }
}