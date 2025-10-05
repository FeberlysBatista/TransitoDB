using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Domain.Interfaces.IServices
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado> GetByIdAsync(int id);
        Task<Empleado> GetByDocumentoAsync(string documento);
        Task<IEnumerable<Empleado>> GetByCargoAsync(int cargoId);
        Task<Empleado> AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
    }
}