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
    public class MultaDetalleAppService : IMultaDetalleAppService
    {
        private readonly IMultaDetalleService _multaDetalleService;
        private readonly IMapper _mapper;

        public MultaDetalleAppService(IMultaDetalleService multaDetalleService, IMapper mapper)
        {
            _multaDetalleService = multaDetalleService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MultaDetalleDto>> GetAllAsync()
        {
            var multaDetalles = await _multaDetalleService.GetAllAsync();
            return _mapper.Map<IEnumerable<MultaDetalleDto>>(multaDetalles);
        }

        public async Task<MultaDetalleDto> GetByIdAsync(long id)
        {
            var multaDetalle = await _multaDetalleService.GetByIdAsync(id);
            return _mapper.Map<MultaDetalleDto>(multaDetalle);
        }

        public async Task<IEnumerable<MultaDetalleDto>> GetByMultaIdAsync(long multaId)
        {
            var multaDetalles = await _multaDetalleService.GetByMultaIdAsync(multaId);
            return _mapper.Map<IEnumerable<MultaDetalleDto>>(multaDetalles);
        }

        public async Task<MultaDetalleDto> AddAsync(MultaDetalleDto multaDetalleDto)
        {
            var multaDetalle = _mapper.Map<MultaDetalle>(multaDetalleDto);
            var result = await _multaDetalleService.AddAsync(multaDetalle);
            return _mapper.Map<MultaDetalleDto>(result);
        }

        public async Task UpdateAsync(MultaDetalleDto multaDetalleDto)
        {
            var multaDetalle = _mapper.Map<MultaDetalle>(multaDetalleDto);
            await _multaDetalleService.UpdateAsync(multaDetalle);
        }

        public async Task DeleteAsync(long id)
        {
            await _multaDetalleService.DeleteAsync(id);
        }
    }
}