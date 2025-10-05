using TransitoDB.Domain.Interfaces;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;

namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface IMultaRepository : IGenericRepository<Multa>
    {
        Task<IEnumerable<Multa>> GetMultasByConductorAsync(int conductorId);
        Task<Multa> GetMultaWithDetailsAsync(long multaId);
        Task<IEnumerable<Multa>> GetMultasConSaldoAsync();
        Task<long> EmitirMultaAsync(Multa multa, IEnumerable<MultaDetalle> detalles);
        Task RegistrarPagoAsync(Pago pago);
        Task AnularRenglonMultaAsync(long multaDetalleId, int agenteId, string motivo);
    }
}
