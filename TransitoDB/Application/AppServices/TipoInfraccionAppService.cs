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
    public class TipoInfraccionAppService : ITipoInfraccionAppService
    {
        private readonly ITipoInfraccionService _tipoInfraccionService;
        private readonly IMapper _mapper;

        public TipoInfraccionAppService(ITipoInfraccionService tipoInfraccionService, IMapper mapper)
        {
            _tipoInfraccionService = tipoInfraccionService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoInfraccionDto>> GetAllAsync()
        {
            var tiposInfraccion = await _tipoInfraccionService.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoInfraccionDto>>(tiposInfraccion);
        }

        public async Task<TipoInfraccionDto> GetByIdAsync(int id)
        {
            var tipoInfraccion = await _tipoInfraccionService.GetByIdAsync(id);
            return _mapper.Map<TipoInfraccionDto>(tipoInfraccion);
        }

        public async Task<TipoInfraccionDto> GetByCodigoAsync(string codigo)
        {
            var tipoInfraccion = await _tipoInfraccionService.GetByCodigoAsync(codigo);
            return _mapper.Map<TipoInfraccionDto>(tipoInfraccion);
        }

        public async Task<TipoInfraccionDto> AddAsync(TipoInfraccionDto tipoInfraccionDto)
        {
            var tipoInfraccion = _mapper.Map<TipoInfraccion>(tipoInfraccionDto);
            var result = await _tipoInfraccionService.AddAsync(tipoInfraccion);
            return _mapper.Map<TipoInfraccionDto>(result);
        }

        public async Task UpdateAsync(TipoInfraccionDto tipoInfraccionDto)
        {
            var tipoInfraccion = _mapper.Map<TipoInfraccion>(tipoInfraccionDto);
            await _tipoInfraccionService.UpdateAsync(tipoInfraccion);
        }

        public async Task DeleteAsync(int id)
        {
            await _tipoInfraccionService.DeleteAsync(id);
        }
    }
}