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
    public class UnidadService : IUnidadService
    {
        private readonly IUnidadRepository _unidadRepository;
        private readonly IMapper _mapper;

        public UnidadService(IUnidadRepository unidadRepository, IMapper mapper)
        {
            _unidadRepository = unidadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Unidad>> GetAllAsync()
        {
            return await _unidadRepository.GetAllAsync();
        }

        public async Task<Unidad> GetByIdAsync(int id)
        {
            return await _unidadRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Unidad>> GetByProvinciaAsync(string provincia)
        {
            return await _unidadRepository.GetByProvinciaAsync(provincia);
        }

        public async Task<Unidad> AddAsync(Unidad unidad)
        {
            await _unidadRepository.AddAsync(unidad);
            await _unidadRepository.SaveChangesAsync();
            return unidad;
        }

        public async Task UpdateAsync(Unidad unidad)
        {
            _unidadRepository.Update(unidad);
            await _unidadRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unidad = await _unidadRepository.GetByIdAsync(id);
            if (unidad != null)
            {
                _unidadRepository.Delete(unidad);
                await _unidadRepository.SaveChangesAsync();
            }
        }
    }
}