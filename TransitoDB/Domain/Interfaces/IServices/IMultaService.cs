using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IMultaService
    {
        Task<IEnumerable<Multa>> GetAllAsync();
        Task<Multa> GetByIdAsync(long id);
        Task<IEnumerable<Multa>> GetMultasByConductorAsync(int conductorId);
        Task<Multa> GetMultaWithDetailsAsync(long multaId);
        Task<IEnumerable<Multa>> GetMultasConSaldoAsync();
        Task<Multa> EmitirMultaAsync(Multa multa, IEnumerable<MultaDetalle> detalles);
        Task RegistrarPagoAsync(Pago pago);
        Task AnularRenglonMultaAsync(long multaDetalleId, int agenteId, string motivo);
    }
}