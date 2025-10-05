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
    public class VehiculoAppService : IVehiculoAppService
    {
        private readonly IVehiculoService _vehiculoService;
        private readonly IMapper _mapper;

        public VehiculoAppService(IVehiculoService vehiculoService, IMapper mapper)
        {
            _vehiculoService = vehiculoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehiculoDto>> GetAllAsync()
        {
            var vehiculos = await _vehiculoService.GetAllAsync();
            return _mapper.Map<IEnumerable<VehiculoDto>>(vehiculos);
        }

        public async Task<VehiculoDto> GetByIdAsync(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            return _mapper.Map<VehiculoDto>(vehiculo);
        }

        public async Task<VehiculoDto> GetByPlacaAsync(string placa)
        {
            var vehiculo = await _vehiculoService.GetByPlacaAsync(placa);
            return _mapper.Map<VehiculoDto>(vehiculo);
        }

        public async Task<VehiculoDto> GetByVINAsync(string vin)
        {
            var vehiculo = await _vehiculoService.GetByVINAsync(vin);
            return _mapper.Map<VehiculoDto>(vehiculo);
        }

        public async Task<VehiculoDto> AddAsync(VehiculoDto vehiculoDto)
        {
            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDto);
            var result = await _vehiculoService.AddAsync(vehiculo);
            return _mapper.Map<VehiculoDto>(result);
        }

        public async Task UpdateAsync(VehiculoDto vehiculoDto)
        {
            var vehiculo = _mapper.Map<Vehiculo>(vehiculoDto);
            await _vehiculoService.UpdateAsync(vehiculo);
        }

        public async Task DeleteAsync(int id)
        {
            await _vehiculoService.DeleteAsync(id);
        }
    }
}