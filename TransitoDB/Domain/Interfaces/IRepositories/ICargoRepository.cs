using TransitoDB.Domain.Entities;


namespace TransitoDB.Domain.Interfaces.IRepositories
{
    public interface ICargoRepository : IGenericRepository<Cargo>
    {
        Task<Cargo> GetByNombreAsync(string nombre);
    }
}