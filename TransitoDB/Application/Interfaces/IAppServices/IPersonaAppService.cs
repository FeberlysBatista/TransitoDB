using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IPersonaAppService
    {
        Task<IEnumerable<PersonaDto>> GetAllAsync();
        Task<PersonaDto> GetByIdAsync(int id);
        Task<PersonaDto> GetByCedulaAsync(string cedula);
        Task<PersonaDto> AddAsync(PersonaDto personaDto);
        Task UpdateAsync(PersonaDto personaDto);
        Task DeleteAsync(int id);
    }
} 