using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IAplicacionPagoAppService
    {
        Task<IEnumerable<AplicacionPagoDto>> GetAllAsync();
        Task<AplicacionPagoDto> GetByIdAsync(long id);
        Task<decimal> GetTotalAplicadoByMultaDetalleIdAsync(long multaDetalleId);
        Task<AplicacionPagoDto> AddAsync(AplicacionPagoDto aplicacionPagoDto);
        Task UpdateAsync(AplicacionPagoDto aplicacionPagoDto);
        Task DeleteAsync(long id);
    }
}