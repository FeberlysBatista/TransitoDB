using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Domain.Interfaces.IServices;
using TransitoDB.Domain.Entities;




namespace TransitoDB.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoService(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return await _cargoRepository.GetAllAsync();
        }

        public async Task<Cargo> GetByIdAsync(int id)
        {
            return await _cargoRepository.GetByIdAsync(id);
        }

        public async Task<Cargo> GetByNombreAsync(string nombre)
        {
            return await _cargoRepository.GetByNombreAsync(nombre);
        }

        public async Task<Cargo> AddAsync(Cargo cargo)
        {
            await _cargoRepository.AddAsync(cargo);
            await _cargoRepository.SaveChangesAsync();
            return cargo;
        }

        public async Task UpdateAsync(Cargo cargo)
        {
            _cargoRepository.Update(cargo);
            await _cargoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cargo = await _cargoRepository.GetByIdAsync(id);
            if (cargo != null)
            {
                _cargoRepository.Delete(cargo);
                await _cargoRepository.SaveChangesAsync();
            }
        }
    }
}