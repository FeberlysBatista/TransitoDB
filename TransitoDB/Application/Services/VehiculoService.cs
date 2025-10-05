using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Domain.Interfaces.IServices;

namespace TransitoDB.Application.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IMapper _mapper;

        public VehiculoService(IVehiculoRepository vehiculoRepository, IMapper mapper)
        {
            _vehiculoRepository = vehiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _vehiculoRepository.GetAllAsync();
        }

        public async Task<Vehiculo> GetByIdAsync(int id)
        {
            return await _vehiculoRepository.GetByIdAsync(id);
        }

        public async Task<Vehiculo> GetByPlacaAsync(string placa)
        {
            return await _vehiculoRepository.GetByPlacaAsync(placa);
        }

        public async Task<Vehiculo> GetByVINAsync(string vin)
        {
            return await _vehiculoRepository.GetByVINAsync(vin);
        }

        public async Task<Vehiculo> AddAsync(Vehiculo vehiculo)
        {
            await _vehiculoRepository.AddAsync(vehiculo);
            await _vehiculoRepository.SaveChangesAsync();
            return vehiculo;
        }

        public async Task UpdateAsync(Vehiculo vehiculo)
        {
            _vehiculoRepository.Update(vehiculo);
            await _vehiculoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vehiculo = await _vehiculoRepository.GetByIdAsync(id);
            if (vehiculo != null)
            {
                _vehiculoRepository.Delete(vehiculo);
                await _vehiculoRepository.SaveChangesAsync();
            }
        }
    }
}