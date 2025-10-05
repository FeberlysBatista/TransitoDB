using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IHistorialEstadoMultaAppService
    {
        Task<IEnumerable<HistorialEstadoMultaDto>> GetAllAsync();
        Task<HistorialEstadoMultaDto> GetByIdAsync(long id);
        Task<IEnumerable<HistorialEstadoMultaDto>> GetByMultaIdAsync(long multaId);
        Task<HistorialEstadoMultaDto> AddAsync(HistorialEstadoMultaDto historialEstadoMultaDto);
        Task UpdateAsync(HistorialEstadoMultaDto historialEstadoMultaDto);
        Task DeleteAsync(long id);
    }
}