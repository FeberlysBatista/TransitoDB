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
    public class TipoInfraccionService : ITipoInfraccionService
    {
        private readonly ITipoInfraccionRepository _tipoInfraccionRepository;
        private readonly IMapper _mapper;

        public TipoInfraccionService(ITipoInfraccionRepository tipoInfraccionRepository, IMapper mapper)
        {
            _tipoInfraccionRepository = tipoInfraccionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoInfraccion>> GetAllAsync()
        {
            return await _tipoInfraccionRepository.GetAllAsync();
        }

        public async Task<TipoInfraccion> GetByIdAsync(int id)
        {
            return await _tipoInfraccionRepository.GetByIdAsync(id);
        }

        public async Task<TipoInfraccion> GetByCodigoAsync(string codigo)
        {
            return await _tipoInfraccionRepository.GetByCodigoAsync(codigo);
        }

        public async Task<TipoInfraccion> AddAsync(TipoInfraccion tipoInfraccion)
        {
            await _tipoInfraccionRepository.AddAsync(tipoInfraccion);
            await _tipoInfraccionRepository.SaveChangesAsync();
            return tipoInfraccion;
        }

        public async Task UpdateAsync(TipoInfraccion tipoInfraccion)
        {
            _tipoInfraccionRepository.Update(tipoInfraccion);
            await _tipoInfraccionRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tipoInfraccion = await _tipoInfraccionRepository.GetByIdAsync(id);
            if (tipoInfraccion != null)
            {
                _tipoInfraccionRepository.Delete(tipoInfraccion);
                await _tipoInfraccionRepository.SaveChangesAsync();
            }
        }
    }
}
