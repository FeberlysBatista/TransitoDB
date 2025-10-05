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
    public class EmpleadoAppService : IEmpleadoAppService
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleadoAppService(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpleadoDto>> GetAllAsync()
        {
            var empleados = await _empleadoService.GetAllAsync();
            return _mapper.Map<IEnumerable<EmpleadoDto>>(empleados);
        }

        public async Task<EmpleadoDto> GetByIdAsync(int id)
        {
            var empleado = await _empleadoService.GetByIdAsync(id);
            return _mapper.Map<EmpleadoDto>(empleado);
        }

        public async Task<EmpleadoDto> GetByDocumentoAsync(string documento)
        {
            var empleado = await _empleadoService.GetByDocumentoAsync(documento);
            return _mapper.Map<EmpleadoDto>(empleado);
        }

        public async Task<IEnumerable<EmpleadoDto>> GetByCargoAsync(int cargoId)
        {
            var empleados = await _empleadoService.GetByCargoAsync(cargoId);
            return _mapper.Map<IEnumerable<EmpleadoDto>>(empleados);
        }

        public async Task<EmpleadoDto> AddAsync(EmpleadoDto empleadoDto)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDto);
            var result = await _empleadoService.AddAsync(empleado);
            return _mapper.Map<EmpleadoDto>(result);
        }

        public async Task UpdateAsync(EmpleadoDto empleadoDto)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDto);
            await _empleadoService.UpdateAsync(empleado);
        }

        public async Task DeleteAsync(int id)
        {
            await _empleadoService.DeleteAsync(id);
        }
    }
}