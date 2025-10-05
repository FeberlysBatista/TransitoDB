using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface IUnidadAppService
    {
        Task<IEnumerable<UnidadDto>> GetAllAsync();
        Task<UnidadDto> GetByIdAsync(int id);
        Task<IEnumerable<UnidadDto>> GetByProvinciaAsync(string provincia);
        Task<UnidadDto> AddAsync(UnidadDto unidadDto);
        Task UpdateAsync(UnidadDto unidadDto);
        Task DeleteAsync(int id);
    }
}