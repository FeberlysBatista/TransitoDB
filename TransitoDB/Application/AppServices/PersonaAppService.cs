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
    public class PersonaAppService : IPersonaAppService
    {
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;

        public PersonaAppService(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonaDto>> GetAllAsync()
        {
            var personas = await _personaService.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonaDto>>(personas);
        }

        public async Task<PersonaDto> GetByIdAsync(int id)
        {
            var persona = await _personaService.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(persona);
        }

        public async Task<PersonaDto> GetByCedulaAsync(string cedula)
        {
            var persona = await _personaService.GetByCedulaAsync(cedula);
            return _mapper.Map<PersonaDto>(persona);
        }

        public async Task<PersonaDto> AddAsync(PersonaDto personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            var result = await _personaService.AddAsync(persona);
            return _mapper.Map<PersonaDto>(result);
        }

        public async Task UpdateAsync(PersonaDto personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            await _personaService.UpdateAsync(persona);
        }

        public async Task DeleteAsync(int id)
        {
            await _personaService.DeleteAsync(id);
        }
    }
}