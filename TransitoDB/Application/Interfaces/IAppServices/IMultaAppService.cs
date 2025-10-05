using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IMultaAppService
    {
        Task<IEnumerable<MultaDto>> GetAllAsync();
        Task<MultaDto> GetByIdAsync(long id);
        Task<IEnumerable<MultaDto>> GetMultasByConductorAsync(int conductorId);
        Task<MultaDto> GetMultaWithDetailsAsync(long multaId);
        Task<IEnumerable<MultaDto>> GetMultasConSaldoAsync();
        Task<MultaDto> EmitirMultaAsync(MultaEmitirDto multaEmitirDto);
        Task<PagoDto> RegistrarPagoAsync(PagoRegistrarDto pagoDto);
        Task AnularRenglonMultaAsync(long multaDetalleId, int agenteId, string motivo);
    }
}