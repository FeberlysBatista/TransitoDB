using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IServices;

namespace TransitoDB.Application.AppServices
{
    public class PropiedadVehiculoAppService : IPropiedadVehiculoAppService
    {
        private readonly IPropiedadVehiculoService _propiedadVehiculoService;
        private readonly IMapper _mapper;

        public PropiedadVehiculoAppService(IPropiedadVehiculoService propiedadVehiculoService, IMapper mapper)
        {
            _propiedadVehiculoService = propiedadVehiculoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropiedadVehiculoDto>> GetAllAsync()
        {
            var propiedades = await _propiedadVehiculoService.GetAllAsync();
            return _mapper.Map<IEnumerable<PropiedadVehiculoDto>>(propiedades);
        }

        public async Task<PropiedadVehiculoDto> GetByIdAsync(int vehiculoId, int conductorId, DateTime desde)
        {
            var propiedad = await _propiedadVehiculoService.GetByIdAsync(vehiculoId, conductorId, desde);
            return _mapper.Map<PropiedadVehiculoDto>(propiedad);
        }

        public async Task<IEnumerable<PropiedadVehiculoDto>> GetByVehiculoIdAsync(int vehiculoId)
        {
            var propiedades = await _propiedadVehiculoService.GetByVehiculoIdAsync(vehiculoId);
            return _mapper.Map<IEnumerable<PropiedadVehiculoDto>>(propiedades);
        }

        public async Task<IEnumerable<PropiedadVehiculoDto>> GetByConductorIdAsync(int conductorId)
        {
            var propiedades = await _propiedadVehiculoService.GetByConductorIdAsync(conductorId);
            return _mapper.Map<IEnumerable<PropiedadVehiculoDto>>(propiedades);
        }

        public async Task<PropiedadVehiculoDto> GetVigenteByVehiculoIdAsync(int vehiculoId, DateTime fecha)
        {
            var propiedad = await _propiedadVehiculoService.GetVigenteByVehiculoIdAsync(vehiculoId, fecha);
            return _mapper.Map<PropiedadVehiculoDto>(propiedad);
        }

        public async Task<PropiedadVehiculoDto> AddAsync(PropiedadVehiculoDto propiedadVehiculoDto)
        {
            var propiedad = _mapper.Map<PropiedadVehiculo>(propiedadVehiculoDto);
            var result = await _propiedadVehiculoService.AddAsync(propiedad);
            return _mapper.Map<PropiedadVehiculoDto>(result);
        }

        public async Task UpdateAsync(PropiedadVehiculoDto propiedadVehiculoDto)
        {
            var propiedad = _mapper.Map<PropiedadVehiculo>(propiedadVehiculoDto);
            await _propiedadVehiculoService.UpdateAsync(propiedad);
        }

        public async Task DeleteAsync(int vehiculoId, int conductorId, DateTime desde)
        {
            await _propiedadVehiculoService.DeleteAsync(vehiculoId, conductorId, desde);
        }
    }
}