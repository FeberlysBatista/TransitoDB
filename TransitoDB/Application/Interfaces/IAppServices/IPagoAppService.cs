using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IPagoAppService
    {
        Task<IEnumerable<PagoDto>> GetAllAsync();
        Task<PagoDto> GetByIdAsync(long id);
        Task<IEnumerable<PagoDto>> GetByMultaIdAsync(long multaId);
        Task<PagoDto> AddAsync(PagoDto pagoDto);
        Task UpdateAsync(PagoDto pagoDto);
        Task DeleteAsync(long id);
    }
}