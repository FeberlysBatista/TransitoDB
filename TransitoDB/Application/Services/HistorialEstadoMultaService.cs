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
    public class HistorialEstadoMultaService : IHistorialEstadoMultaService
    {
        private readonly IHistorialEstadoMultaRepository _historialEstadoMultaRepository;
        private readonly IMapper _mapper;

        public HistorialEstadoMultaService(IHistorialEstadoMultaRepository historialEstadoMultaRepository, IMapper mapper)
        {
            _historialEstadoMultaRepository = historialEstadoMultaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HistorialEstadoMulta>> GetAllAsync()
        {
            return await _historialEstadoMultaRepository.GetAllAsync();
        }

        public async Task<HistorialEstadoMulta> GetByIdAsync(long id)
        {
            return await _historialEstadoMultaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<HistorialEstadoMulta>> GetByMultaIdAsync(long multaId)
        {
            return await _historialEstadoMultaRepository.GetByMultaIdAsync(multaId);
        }

        public async Task<HistorialEstadoMulta> AddAsync(HistorialEstadoMulta historialEstadoMulta)
        {
            await _historialEstadoMultaRepository.AddAsync(historialEstadoMulta);
            await _historialEstadoMultaRepository.SaveChangesAsync();
            return historialEstadoMulta;
        }

        public async Task UpdateAsync(HistorialEstadoMulta historialEstadoMulta)
        {
            _historialEstadoMultaRepository.Update(historialEstadoMulta);
            await _historialEstadoMultaRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var historialEstadoMulta = await _historialEstadoMultaRepository.GetByIdAsync(id);
            if (historialEstadoMulta != null)
            {
                _historialEstadoMultaRepository.Delete(historialEstadoMulta);
                await _historialEstadoMultaRepository.SaveChangesAsync();
            }
        }
    }
}