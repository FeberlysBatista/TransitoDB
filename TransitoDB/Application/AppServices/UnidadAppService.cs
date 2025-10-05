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
    public class UnidadAppService : IUnidadAppService
    {
        private readonly IUnidadService _unidadService;
        private readonly IMapper _mapper;

        public UnidadAppService(IUnidadService unidadService, IMapper mapper)
        {
            _unidadService = unidadService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnidadDto>> GetAllAsync()
        {
            var unidades = await _unidadService.GetAllAsync();
            return _mapper.Map<IEnumerable<UnidadDto>>(unidades);
        }

        public async Task<UnidadDto> GetByIdAsync(int id)
        {
            var unidad = await _unidadService.GetByIdAsync(id);
            return _mapper.Map<UnidadDto>(unidad);
        }

        public async Task<IEnumerable<UnidadDto>> GetByProvinciaAsync(string provincia)
        {
            var unidades = await _unidadService.GetByProvinciaAsync(provincia);
            return _mapper.Map<IEnumerable<UnidadDto>>(unidades);
        }

        public async Task<UnidadDto> AddAsync(UnidadDto unidadDto)
        {
            var unidad = _mapper.Map<Unidad>(unidadDto);
            var result = await _unidadService.AddAsync(unidad);
            return _mapper.Map<UnidadDto>(result);
        }

        public async Task UpdateAsync(UnidadDto unidadDto)
        {
            var unidad = _mapper.Map<Unidad>(unidadDto);
            await _unidadService.UpdateAsync(unidad);
        }

        public async Task DeleteAsync(int id)
        {
            await _unidadService.DeleteAsync(id);
        }
    }
}