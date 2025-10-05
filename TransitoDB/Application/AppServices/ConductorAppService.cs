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
    public class ConductorAppService : IConductorAppService
    {
        private readonly IConductorService _conductorService;
        private readonly IMapper _mapper;

        public ConductorAppService(IConductorService conductorService, IMapper mapper)
        {
            _conductorService = conductorService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConductorDto>> GetAllAsync()
        {
            var conductores = await _conductorService.GetAllAsync();
            return _mapper.Map<IEnumerable<ConductorDto>>(conductores);
        }

        public async Task<ConductorDto> GetByIdAsync(int id)
        {
            var conductor = await _conductorService.GetByIdAsync(id);
            return _mapper.Map<ConductorDto>(conductor);
        }

        public async Task<ConductorDto> GetByLicenciaAsync(string licenciaNro)
        {
            var conductor = await _conductorService.GetByLicenciaAsync(licenciaNro);
            return _mapper.Map<ConductorDto>(conductor);
        }

        public async Task<ConductorDto> GetByCedulaAsync(string cedula)
        {
            var conductor = await _conductorService.GetByCedulaAsync(cedula);
            return _mapper.Map<ConductorDto>(conductor);
        }

        public async Task<ConductorDto> AddAsync(ConductorDto conductorDto)
        {
            var conductor = _mapper.Map<Conductor>(conductorDto);
            var result = await _conductorService.AddAsync(conductor);
            return _mapper.Map<ConductorDto>(result);
        }

        public async Task UpdateAsync(ConductorDto conductorDto)
        {
            var conductor = _mapper.Map<Conductor>(conductorDto);
            await _conductorService.UpdateAsync(conductor);
        }

        public async Task DeleteAsync(int id)
        {
            await _conductorService.DeleteAsync(id);
        }
    }
}