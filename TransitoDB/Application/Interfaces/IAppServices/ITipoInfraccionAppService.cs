using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface ITipoInfraccionAppService
    {
        Task<IEnumerable<TipoInfraccionDto>> GetAllAsync();
        Task<TipoInfraccionDto> GetByIdAsync(int id);
        Task<TipoInfraccionDto> GetByCodigoAsync(string codigo);
        Task<TipoInfraccionDto> AddAsync(TipoInfraccionDto tipoInfraccionDto);
        Task UpdateAsync(TipoInfraccionDto tipoInfraccionDto);
        Task DeleteAsync(int id);
    }
}