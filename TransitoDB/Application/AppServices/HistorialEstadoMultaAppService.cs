using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IServices;

namespace TransitoApp.Application.AppServices
{
    public class HistorialEstadoMultaAppService : IHistorialEstadoMultaAppService
    {
        private readonly IHistorialEstadoMultaService _historialEstadoMultaService;
        private readonly IMapper _mapper;

        public HistorialEstadoMultaAppService(IHistorialEstadoMultaService historialEstadoMultaService, IMapper mapper)
        {
            _historialEstadoMultaService = historialEstadoMultaService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HistorialEstadoMultaDto>> GetAllAsync()
        {
            var historiales = await _historialEstadoMultaService.GetAllAsync();
            return _mapper.Map<IEnumerable<HistorialEstadoMultaDto>>(historiales);
        }

        public async Task<HistorialEstadoMultaDto> GetByIdAsync(long id)
        {
            var historial = await _historialEstadoMultaService.GetByIdAsync(id);
            return _mapper.Map<HistorialEstadoMultaDto>(historial);
        }

        public async Task<IEnumerable<HistorialEstadoMultaDto>> GetByMultaIdAsync(long multaId)
        {
            var historiales = await _historialEstadoMultaService.GetByMultaIdAsync(multaId);
            return _mapper.Map<IEnumerable<HistorialEstadoMultaDto>>(historiales);
        }

        public async Task<HistorialEstadoMultaDto> AddAsync(HistorialEstadoMultaDto historialEstadoMultaDto)
        {
            var historial = _mapper.Map<HistorialEstadoMulta>(historialEstadoMultaDto);
            var result = await _historialEstadoMultaService.AddAsync(historial);
            return _mapper.Map<HistorialEstadoMultaDto>(result);
        }

        public async Task UpdateAsync(HistorialEstadoMultaDto historialEstadoMultaDto)
        {
            var historial = _mapper.Map<HistorialEstadoMulta>(historialEstadoMultaDto);
            await _historialEstadoMultaService.UpdateAsync(historial);
        }

        public async Task DeleteAsync(long id)
        {
            await _historialEstadoMultaService.DeleteAsync(id);
        }
    }
}