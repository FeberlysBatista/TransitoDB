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
    public class ConductorService : IConductorService
    {
        private readonly IConductorRepository _conductorRepository;
        private readonly IMapper _mapper;

        public ConductorService(IConductorRepository conductorRepository, IMapper mapper)
        {
            _conductorRepository = conductorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Conductor>> GetAllAsync()
        {
            return await _conductorRepository.GetAllAsync();
        }

        public async Task<Conductor> GetByIdAsync(int id)
        {
            return await _conductorRepository.GetByIdAsync(id);
        }

        public async Task<Conductor> GetByLicenciaAsync(string licenciaNro)
        {
            return await _conductorRepository.GetByLicenciaAsync(licenciaNro);
        }

        public async Task<Conductor> GetByCedulaAsync(string cedula)
        {
            return await _conductorRepository.GetByCedulaAsync(cedula);
        }

        public async Task<Conductor> AddAsync(Conductor conductor)
        {
            await _conductorRepository.AddAsync(conductor);
            await _conductorRepository.SaveChangesAsync();
            return conductor;
        }

        public async Task UpdateAsync(Conductor conductor)
        {
            _conductorRepository.Update(conductor);
            await _conductorRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var conductor = await _conductorRepository.GetByIdAsync(id);
            if (conductor != null)
            {
                _conductorRepository.Delete(conductor);
                await _conductorRepository.SaveChangesAsync();
            }
        }
    }
}