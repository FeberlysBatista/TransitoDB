using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Domain.Interfaces.IServices;

namespace TransitoDB.Application.Services
{
    public class PropiedadVehiculoService : IPropiedadVehiculoService
    {
        private readonly IPropiedadVehiculoRepository _propiedadVehiculoRepository;
        private readonly IMapper _mapper;

        public PropiedadVehiculoService(IPropiedadVehiculoRepository propiedadVehiculoRepository, IMapper mapper)
        {
            _propiedadVehiculoRepository = propiedadVehiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropiedadVehiculo>> GetAllAsync()
        {
            return await _propiedadVehiculoRepository.GetAllAsync();
        }

        public async Task<PropiedadVehiculo> GetByIdAsync(int vehiculoId, int conductorId, DateTime desde)
        {
            // Como es una clave compuesta, necesitamos buscar por todos los campos
            var propiedades = await _propiedadVehiculoRepository.FindAsync(p =>
                p.VehiculoId == vehiculoId &&
                p.ConductorId == conductorId &&
                p.Desde == desde);

            return propiedades.FirstOrDefault();
        }

        public async Task<IEnumerable<PropiedadVehiculo>> GetByVehiculoIdAsync(int vehiculoId)
        {
            return await _propiedadVehiculoRepository.GetByVehiculoIdAsync(vehiculoId);
        }

        public async Task<IEnumerable<PropiedadVehiculo>> GetByConductorIdAsync(int conductorId)
        {
            return await _propiedadVehiculoRepository.GetByConductorIdAsync(conductorId);
        }

        public async Task<PropiedadVehiculo> GetVigenteByVehiculoIdAsync(int vehiculoId, DateTime fecha)
        {
            return await _propiedadVehiculoRepository.GetVigenteByVehiculoIdAsync(vehiculoId, fecha);
        }

        public async Task<PropiedadVehiculo> AddAsync(PropiedadVehiculo propiedadVehiculo)
        {
            await _propiedadVehiculoRepository.AddAsync(propiedadVehiculo);
            await _propiedadVehiculoRepository.SaveChangesAsync();
            return propiedadVehiculo;
        }

        public async Task UpdateAsync(PropiedadVehiculo propiedadVehiculo)
        {
            _propiedadVehiculoRepository.Update(propiedadVehiculo);
            await _propiedadVehiculoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int vehiculoId, int conductorId, DateTime desde)
        {
            var propiedad = await GetByIdAsync(vehiculoId, conductorId, desde);
            if (propiedad != null)
            {
                _propiedadVehiculoRepository.Delete(propiedad);
                await _propiedadVehiculoRepository.SaveChangesAsync();
            }
        }
    }
}