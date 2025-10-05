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
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _personaRepository.GetAllAsync();
        }

        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _personaRepository.GetByIdAsync(id);
        }

        public async Task<Persona> GetByCedulaAsync(string cedula)
        {
            return await _personaRepository.GetByCedulaAsync(cedula);
        }

        public async Task<Persona> AddAsync(Persona persona)
        {
            await _personaRepository.AddAsync(persona);
            await _personaRepository.SaveChangesAsync();
            return persona;
        }

        public async Task UpdateAsync(Persona persona)
        {
            _personaRepository.Update(persona);
            await _personaRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            if (persona != null)
            {
                _personaRepository.Delete(persona);
                await _personaRepository.SaveChangesAsync();
            }
        }
    }
}