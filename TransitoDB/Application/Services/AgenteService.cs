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
    public class AgenteService : IAgenteService
    {
        private readonly IAgenteRepository _agenteRepository;
        private readonly IMapper _mapper;

        public AgenteService(IAgenteRepository agenteRepository, IMapper mapper)
        {
            _agenteRepository = agenteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Agente>> GetAllAsync()
        {
            return await _agenteRepository.GetAllAsync();
        }

        public async Task<Agente> GetByIdAsync(int id)
        {
            return await _agenteRepository.GetByIdAsync(id);
        }

        public async Task<Agente> GetByMatriculaAsync(string matricula)
        {
            return await _agenteRepository.GetByMatriculaAsync(matricula);
        }

        public async Task<IEnumerable<Agente>> GetByUnidadAsync(int unidadId)
        {
            return await _agenteRepository.GetByUnidadAsync(unidadId);
        }

        public async Task<Agente> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _agenteRepository.GetByEmpleadoIdAsync(empleadoId);
        }

        public async Task<Agente> AddAsync(Agente agente)
        {
            await _agenteRepository.AddAsync(agente);
            await _agenteRepository.SaveChangesAsync();
            return agente;
        }

        public async Task UpdateAsync(Agente agente)
        {
            _agenteRepository.Update(agente);
            await _agenteRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agente = await _agenteRepository.GetByIdAsync(id);
            if (agente != null)
            {
                _agenteRepository.Delete(agente);
                await _agenteRepository.SaveChangesAsync();
            }
        }
    }
}