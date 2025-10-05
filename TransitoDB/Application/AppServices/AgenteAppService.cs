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
    public class AgenteAppService : IAgenteAppService
    {
        private readonly IAgenteService _agenteService;
        private readonly IMapper _mapper;

        public AgenteAppService(IAgenteService agenteService, IMapper mapper)
        {
            _agenteService = agenteService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgenteDto>> GetAllAsync()
        {
            var agentes = await _agenteService.GetAllAsync();
            return _mapper.Map<IEnumerable<AgenteDto>>(agentes);
        }

        public async Task<AgenteDto> GetByIdAsync(int id)
        {
            var agente = await _agenteService.GetByIdAsync(id);
            return _mapper.Map<AgenteDto>(agente);
        }

        public async Task<AgenteDto> GetByMatriculaAsync(string matricula)
        {
            var agente = await _agenteService.GetByMatriculaAsync(matricula);
            return _mapper.Map<AgenteDto>(agente);
        }

        public async Task<IEnumerable<AgenteDto>> GetByUnidadAsync(int unidadId)
        {
            var agentes = await _agenteService.GetByUnidadAsync(unidadId);
            return _mapper.Map<IEnumerable<AgenteDto>>(agentes);
        }

        public async Task<AgenteDto> GetByEmpleadoIdAsync(int empleadoId)
        {
            var agente = await _agenteService.GetByEmpleadoIdAsync(empleadoId);
            return _mapper.Map<AgenteDto>(agente);
        }

        public async Task<AgenteDto> AddAsync(AgenteDto agenteDto)
        {
            var agente = _mapper.Map<Agente>(agenteDto);
            var result = await _agenteService.AddAsync(agente);
            return _mapper.Map<AgenteDto>(result);
        }

        public async Task UpdateAsync(AgenteDto agenteDto)
        {
            var agente = _mapper.Map<Agente>(agenteDto);
            await _agenteService.UpdateAsync(agente);
        }

        public async Task DeleteAsync(int id)
        {
            await _agenteService.DeleteAsync(id);
        }
    }
}