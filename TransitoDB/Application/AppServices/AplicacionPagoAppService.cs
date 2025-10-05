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
    public class AplicacionPagoAppService :IAplicacionPagoAppService
    {
        private readonly IAplicacionPagoService _aplicacionPagoService;
        private readonly IMapper _mapper;

        public AplicacionPagoAppService(IAplicacionPagoService aplicacionPagoService, IMapper mapper)
        {
            _aplicacionPagoService = aplicacionPagoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AplicacionPagoDto>> GetAllAsync()
        {
            var aplicaciones = await _aplicacionPagoService.GetAllAsync();
            return _mapper.Map<IEnumerable<AplicacionPagoDto>>(aplicaciones);
        }

        public async Task<AplicacionPagoDto> GetByIdAsync(long id)
        {
            var aplicacion = await _aplicacionPagoService.GetByIdAsync(id);
            return _mapper.Map<AplicacionPagoDto>(aplicacion);
        }

        public async Task<decimal> GetTotalAplicadoByMultaDetalleIdAsync(long multaDetalleId)
        {
            return await _aplicacionPagoService.GetTotalAplicadoByMultaDetalleIdAsync(multaDetalleId);
        }

        public async Task<AplicacionPagoDto> AddAsync(AplicacionPagoDto aplicacionPagoDto)
        {
            var aplicacion = _mapper.Map<AplicacionPago>(aplicacionPagoDto);
            var result = await _aplicacionPagoService.AddAsync(aplicacion);
            return _mapper.Map<AplicacionPagoDto>(result);
        }

        public async Task UpdateAsync(AplicacionPagoDto aplicacionPagoDto)
        {
            var aplicacion = _mapper.Map<AplicacionPago>(aplicacionPagoDto);
            await _aplicacionPagoService.UpdateAsync(aplicacion);
        }

        public async Task DeleteAsync(long id)
        {
            await _aplicacionPagoService.DeleteAsync(id);
        }
    }
}