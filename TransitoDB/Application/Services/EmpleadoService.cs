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
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public EmpleadoService(IEmpleadoRepository empleadoRepository, IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _empleadoRepository.GetAllAsync();
        }

        public async Task<Empleado> GetByIdAsync(int id)
        {
            return await _empleadoRepository.GetByIdAsync(id);
        }

        public async Task<Empleado> GetByDocumentoAsync(string documento)
        {
            return await _empleadoRepository.GetByDocumentoAsync(documento);
        }

        public async Task<IEnumerable<Empleado>> GetByCargoAsync(int cargoId)
        {
            return await _empleadoRepository.GetByCargoAsync(cargoId);
        }

        public async Task<Empleado> AddAsync(Empleado empleado)
        {
            await _empleadoRepository.AddAsync(empleado);
            await _empleadoRepository.SaveChangesAsync();
            return empleado;
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            _empleadoRepository.Update(empleado);
            await _empleadoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado != null)
            {
                _empleadoRepository.Delete(empleado);
                await _empleadoRepository.SaveChangesAsync();
            }
        }
    }
}