using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IMultaDetalleAppService
    {
        Task<IEnumerable<MultaDetalleDto>> GetAllAsync();
        Task<MultaDetalleDto> GetByIdAsync(long id);
        Task<IEnumerable<MultaDetalleDto>> GetByMultaIdAsync(long multaId);
        Task<MultaDetalleDto> AddAsync(MultaDetalleDto multaDetalleDto);
        Task UpdateAsync(MultaDetalleDto multaDetalleDto);
        Task DeleteAsync(long id);
    }
}