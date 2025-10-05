using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.Interfaces.IAppServices
{
    public interface ICargoAppService
    {
        Task<IEnumerable<CargoDto>> GetAllAsync();
        Task<CargoDto> GetByIdAsync(int id);
        Task<CargoDto> AddAsync(CargoDto cargoDto);
        Task UpdateAsync(CargoDto cargoDto);
        Task DeleteAsync(int id);
    }
}